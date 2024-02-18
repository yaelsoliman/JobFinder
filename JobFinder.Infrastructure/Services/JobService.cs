using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Application.Models.ServiceModel;
using JobFinder.Domain.Entities;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace JobFinder.Infrastructure.Services;

public class JobService : BaseService<Job, JobSearch>, IJobService
{
    readonly IStoreContext _storeContext;
    readonly ISkillService _skillService;
    readonly ILanguageService _languageService;
    readonly IRepository<JobQuestionAnswer> _answerRepo;
    readonly IRepository<JobApplicant> _jobApplicantRepo;
    readonly IRepository<JobApplicantLifecycle> _jobLifecycleRepo;

    public JobService(
        IRepository<Job> repo,
        IStoreContext storeContext,
        ISkillService skillService,
        ILanguageService languageService,
        IRepository<JobQuestionAnswer> answerRepo,
        IRepository<JobApplicant> jobApplicantRepo,
        IRepository<JobApplicantLifecycle> jobLifecycleRepo)
        : base(repo)
    {
        _storeContext = storeContext;
        _skillService = skillService;
        _languageService = languageService;
        _answerRepo = answerRepo;
        _jobApplicantRepo = jobApplicantRepo;
        _jobLifecycleRepo = jobLifecycleRepo;
    }

    public async override Task<Job> GetAsync(Guid id, bool asTracking = false, params Expression<Func<Job, object>>[] includes)
    {
        var job = await base.GetAsync(id, asTracking, x => x.Questions, x => x.JobAttachments, x => x.Skills, x => x.Languages, x => x.Company);
        if (job.Skills?.Count > 0)
        {
            foreach (var skillItem in job.Skills)
            {
                skillItem.Skill = await _skillService.GetAsync(skillItem.SkillId);
            }
        }
        if (job.Languages?.Count > 0)
        {
            foreach (var languageItem in job.Languages)
            {
                languageItem.Language = await _languageService.GetAsync(languageItem.LanguageId);
            }
        }
        if (job.Questions?.Count > 0)
        {
            foreach (var questionItem in job.Questions)
            {
                questionItem.JobQuestionAnswers = (await _answerRepo.GetListAsync(x => x.JobQuestionId == questionItem.Id)).ToList();
            }
        }
        if (_storeContext?.Applicant is not null)
        {
            job.IsCurrentUserApplied = (await _jobApplicantRepo.FirstOrDefaultAsync(x => x.ApplicantId == _storeContext.Applicant.Id && x.JobId == job.Id)) is not null;
        }
        return job;
    }

    public override async Task<Guid> CreateAsync(Job model)
    {
        if (model.NewSkills?.Count > 0)
        {
            model.SelectedSkills ??= new();

            foreach (var skill in model.NewSkills)
            {
                model.SelectedSkills.Add(await _skillService.CreateAsync(new Skill { Title = skill }));
            }
        }

        if (model.SelectedSkills?.Count > 0)
        {
            model.Skills = new List<JobSkill>();
            foreach (var skill in model.SelectedSkills)
            {
                model.Skills.Add(new JobSkill { SkillId = skill });
            }
        }

        if (model.SelectedLanguages?.Count > 0)
        {
            model.Languages = new List<JobLanguage>();
            foreach (var language in model.SelectedLanguages)
            {
                model.Languages.Add(new JobLanguage { LanguageId = language });
            }
        }

        return await base.CreateAsync(model);
    }

    public override async Task<Guid> UpdateAsync(Job model)
    {
        var oldModel = await _repo.FindAsync(model.Id) ?? throw new NotFoundException("Job Not Found");
        oldModel.Title = model.Title;
        oldModel.VacancyCount = model.VacancyCount;
        oldModel.MiniContent = model.MiniContent;
        oldModel.Description = model.Description;
        oldModel.JobCode = model.JobCode;
        oldModel.PreferredAge = model.PreferredAge;
        oldModel.JobShift = model.JobShift;
        oldModel.JobLevel = model.JobLevel;
        oldModel.JobType = model.JobType;
        oldModel.WorkHours = model.WorkHours;
        oldModel.FromTime = model.FromTime;
        oldModel.TillTime = model.TillTime;
        oldModel.Salary = model.Salary;
        oldModel.PreferredGender = model.PreferredGender;
        oldModel.PreferredYearsOfExperience = model.PreferredYearsOfExperience;
        oldModel.HasOnlineTest = model.HasOnlineTest;
        oldModel.ApprovedAverage = model.ApprovedAverage;
        oldModel.HasTestInSite = model.HasTestInSite;
        await _repo.SaveChangesAsync();
        return oldModel.Id;
    }

    public async override Task<PaginationResponse<Job>> PaginateAsync(PaginationFilter<JobSearch> filter)
    {
        filter ??= new();
        Filters<Job> filters = new();
        filters.Add(_storeContext.Company is not null, x => x.CompanyId == _storeContext.Company!.Id);
        filters.Add(filter.Keyword.HasValue(), x => x.Title.ToLower().Contains(filter.Keyword.ToLower()));
        PaginationResponse<Job> result = await _repo.PaginateAsync(filter, filters);
        return result;
    }

    public async Task<PaginationResponse<Job>> GetJobsForApplicant(PaginationFilter<JobSearch> filter)
    {
        filter ??= new();
        filter.Search ??= new();
        Filters<Job> filters = new();
        filters.Add(filter.Keyword.HasValue(), x => x.Title.ToLower().Contains(filter.Keyword.ToLower()));
        filters.Add(true, x => x.IsActive == true);
        filters.Add(true, x => x.IsBanned == false);
        filters.Add(_storeContext.Company is not null, x => x.CompanyId == _storeContext.Company!.Id);
        filters.Add(filter.Search.JobCode.HasValue(), x => x.JobCode == filter.Search.JobCode);
        filters.Add(filter.Search.JobLevel.HasValue, x => x.JobLevel == filter.Search.JobLevel);
        filters.Add(filter.Search.JobShift.HasValue, x => x.JobShift == filter.Search.JobShift);
        filters.Add(filter.Search.JobType.HasValue, x => x.JobType == filter.Search.JobType);
        filters.Add(filter.Search.Skills?.Count > 0, x => x.Skills.Any(y => filter.Search.Skills.Any(t => t == y.SkillId)));
        filters.Add(filter.Search.Languages?.Count > 0, x => x.Languages.Any(y => filter.Search.Languages.Any(t => t == y.LanguageId)));
        PaginationResponse<Job> result = await _repo.PaginateAsync(filter, filters, null, x => x.Skills, x => x.Languages, x => x.Company);

        foreach (var item in result.Data)
        {
            if (item.Skills?.Count > 0 && item.Languages?.Count > 0)
            {
                item.IsMatchApplicantProfile = item.Skills.Any(x => _storeContext.Applicant.ApplicantSkills.Any(t => t.SkillId == x.SkillId)) &&
                 item.Languages.Any(x => _storeContext.Applicant.ApplicantLanguages.Any(t => t.LanguageId == x.LanguageId));
                foreach (var item2 in item.Skills)
                {
                    item2.Skill = await _skillService.GetAsync(item2.SkillId);
                }
                foreach (var item2 in item.Languages)
                {
                    item2.Language = await _languageService.GetAsync(item2.LanguageId);
                }
            }
            else if (item.Skills?.Count > 0)
            {
                item.IsMatchApplicantProfile = item.Skills.Any(x => _storeContext.Applicant.ApplicantSkills.Any(t => t.SkillId == x.SkillId));
                foreach (var item2 in item.Skills)
                {
                    item2.Skill = await _skillService.GetAsync(item2.SkillId);
                }
            }
            else if (item.Languages?.Count > 0)
            {
                item.IsMatchApplicantProfile = item.Languages.Any(x => _storeContext.Applicant.ApplicantLanguages.Any(t => t.LanguageId == x.LanguageId));
                foreach (var item2 in item.Languages)
                {
                    item2.Language = await _languageService.GetAsync(item2.LanguageId);
                }
            }
        }

        return result;
    }

    public async Task<Guid> ApplyForJob(Guid jobId, Guid applicantId)
    {
        var job = await _repo.FindAsync(jobId);
        var result = await _jobApplicantRepo.CreateAsync(new JobApplicant
        {
            JobId = jobId,
            ApplicantId = applicantId,
            CurrentStatus = ApplicantRequestStatus.Pending,
            CompanyId = job.CompanyId,
            JobApplicantLifecycles = new List<JobApplicantLifecycle>
            {
                new JobApplicantLifecycle
                {
                    OldStatus = ApplicantRequestStatus.Pending,
                    NewStatus = ApplicantRequestStatus.Pending,
                }
            }
        });
        return result;
    }

    public async Task<Guid> SubmitTest(Guid jobId, List<ApplyJobRequest> applyJobRequest)
    {
        var job = await GetAsync(jobId);
        var percentagePerQuestion = 100 / job.Questions.Count;
        var applicantTotalPercentage = 0;
        foreach (var question in job.Questions)
        {
            if (question.QuestionType == QuestionType.Single)
            {
                if (question.JobQuestionAnswers.FirstOrDefault(x => applyJobRequest.FirstOrDefault(y => y.QuestionId == question.Id).AnswerId == x.Id).IsCorrect)
                {
                    applicantTotalPercentage += percentagePerQuestion;
                }
            }
            if (question.QuestionType == QuestionType.Multiple)
            {
                var percentagePerAnswer = percentagePerQuestion / question.JobQuestionAnswers.Count(x => x.IsCorrect == true);
                foreach (var answer in applyJobRequest.Where(x => x.QuestionId == question.Id))
                {
                    if (question.JobQuestionAnswers.FirstOrDefault(x => x.Id == answer.AnswerId).IsCorrect)
                    {
                        applicantTotalPercentage += percentagePerAnswer;
                    }
                }

            }
        }
        Guid result;
        var jobApplicantRequest = await _jobApplicantRepo.FirstOrDefaultAsync(x => x.JobId == jobId && x.ApplicantId == _storeContext.Applicant.Id);
        jobApplicantRequest.FinishedTest = true;
        if (applicantTotalPercentage >= job.ApprovedAverage)
        {
            jobApplicantRequest.CurrentStatus = ApplicantRequestStatus.PendingApprove;
            result = await _jobLifecycleRepo.CreateAsync(new JobApplicantLifecycle
            {
                OldStatus = ApplicantRequestStatus.Pending,
                NewStatus = ApplicantRequestStatus.PendingApprove,
                JobApplicantId = jobApplicantRequest.Id
            });
        }
        else
        {
            jobApplicantRequest.CurrentStatus = ApplicantRequestStatus.Rejected;
            result = await _jobLifecycleRepo.CreateAsync(new JobApplicantLifecycle
            {
                OldStatus = ApplicantRequestStatus.Pending,
                NewStatus = ApplicantRequestStatus.Rejected,
                Note = "System Auto Reject Depend On Your Mark In Test",
                JobApplicantId = jobApplicantRequest.Id
            });
        }
        return result;
    }

    public async Task<Guid> ApproveApplicant(Guid jobApplicantId)
    {
        var jobApplicantRequest = await _jobApplicantRepo.FirstOrDefaultAsync(x => x.Id == jobApplicantId);
        var currentStatus = jobApplicantRequest.CurrentStatus;
        jobApplicantRequest.CurrentStatus = ApplicantRequestStatus.Approved;
        await _jobApplicantRepo.SaveChangesAsync();
        var result = await _jobLifecycleRepo.CreateAsync(new JobApplicantLifecycle
        {
            OldStatus = currentStatus,
            NewStatus = ApplicantRequestStatus.Approved,
            JobApplicantId = jobApplicantRequest.Id
        });
        return result;
    }

    public async Task<Guid> RejectApplicant(Guid jobApplicantId, string note)
    {
        var jobApplicantRequest = await _jobApplicantRepo.FirstOrDefaultAsync(x => x.Id == jobApplicantId);
        var currentStatus = jobApplicantRequest.CurrentStatus;
        jobApplicantRequest.CurrentStatus = ApplicantRequestStatus.Rejected;
        var result = await _jobLifecycleRepo.CreateAsync(new JobApplicantLifecycle
        {
            OldStatus = currentStatus,
            NewStatus = ApplicantRequestStatus.Rejected,
            Note = note,
            JobApplicantId = jobApplicantRequest.Id
        });
        return result;
    }

    public async Task<PaginationResponse<JobApplicant>> GetCompanyApplicant(PaginationFilter<ApplicantSearch> filter)
    {
        filter ??= new();
        Filters<JobApplicant> filters = new();
        filters.Add(_storeContext.Company is not null, x => x.CompanyId == _storeContext.Company!.Id);
        filters.Add(filter.Keyword.HasValue(), x => x.Applicant.Name.ToLower().Contains(filter.Keyword.ToLower()) ||
                                                    x.Applicant.Email.ToLower().Contains(filter.Keyword.ToLower()) ||
                                                    x.Applicant.Phone.ToLower().Contains(filter.Keyword.ToLower()) ||
                                                    x.Applicant.Mobile.ToLower().Contains(filter.Keyword.ToLower()));

        PaginationResponse<JobApplicant> result = await _jobApplicantRepo.PaginateAsync(filter, filters, x => x.ApplicantId, x => x.Applicant);
        return result;
    }

    public async Task<PaginationResponse<JobApplicant>> GetAppliedJob(PaginationFilter<ApplicantSearch> filter)
    {
        filter ??= new();
        Filters<JobApplicant> filters = new();
        filters.Add(_storeContext.Applicant is not null, x => x.ApplicantId == _storeContext.Applicant!.Id);
        filters.Add(filter.Keyword.HasValue(), x => x.Job.Title.ToLower().Contains(filter.Keyword.ToLower()));
        PaginationResponse<JobApplicant> result = await _jobApplicantRepo.PaginateAsync(filter, filters, null, x => x.Job);
        return result;
    }

    public async Task<PaginationResponse<JobApplicant>> GetApplicantForJob(PaginationFilter<ApplicantJobSearch> filter)
    {
        filter ??= new();
        Filters<JobApplicant> filters = new();
        filters.Add(filter.Search.ApplicantId.HasValue, x => x.ApplicantId == filter.Search.ApplicantId.Value);
        filters.Add(filter.Search.JobId.HasValue, x => x.JobId == filter.Search.JobId.Value);
        filters.Add(filter.Keyword.HasValue(), x => x.Job.Title.ToLower().Contains(filter.Keyword.ToLower()));
        PaginationResponse<JobApplicant> result = await _jobApplicantRepo.PaginateAsync(filter, filters, null, x => x.Job, x=>x.Applicant);
        return result;
    }

    public async Task<Guid> BanJob(Guid jobId)
    {
        var job = await _repo.FirstOrDefaultAsync(x => x.Id == jobId);
        job.IsBanned = true;
        await _repo.SaveChangesAsync();
        return jobId;
    }
}
