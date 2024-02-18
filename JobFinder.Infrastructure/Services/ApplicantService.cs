using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Infrastructure.Store;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace JobFinder.Infrastructure.Services;

public class ApplicantService : BaseService<Applicant, ApplicantSearch>, IApplicantService
{
    readonly ISkillService _skillService;
    readonly ILanguageService _languageService;
    readonly IRepository<ApplicantSkill> _applicantSkillRepo;
    readonly IRepository<ApplicantLanguage> _applicantLanguageRepo;
    readonly IStoreContext _storeContext;

    public ApplicantService(IRepository<Applicant> repo,
        ISkillService skillService,
        ILanguageService languageService,
        IRepository<ApplicantSkill> applicantSkillRepo,
        IRepository<ApplicantLanguage> applicantLanguageRepo,
        IStoreContext storeContext)
        : base(repo)
    {
        _storeContext = storeContext;
        _skillService = skillService;
        _languageService = languageService;
        _applicantSkillRepo = applicantSkillRepo;
        _applicantLanguageRepo = applicantLanguageRepo;
    }

    public override async Task<Guid> CreateAsync(Applicant model)
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
            model.ApplicantSkills = new List<ApplicantSkill>();
            foreach (var skill in model.SelectedSkills)
            {
                model.ApplicantSkills.Add(new ApplicantSkill { SkillId = skill });
            }
        }

        if (model.SelectedLanguages?.Count > 0)
        {
            model.ApplicantLanguages = new List<ApplicantLanguage>();
            foreach (var language in model.SelectedLanguages)
            {
                model.ApplicantLanguages.Add(new ApplicantLanguage { LanguageId = language });
            }
        }

        return await base.CreateAsync(model);
    }

    public async override Task<Guid> UpdateAsync(Applicant model)
    {
        var oldModel = await GetAsync(_storeContext.Applicant!.Id!);
        oldModel.Phone = model.Phone;
        oldModel.Mobile = model.Mobile;
        oldModel.Image = model.Image ?? oldModel.Image;
        oldModel.Gender = model.Gender;
        oldModel.YearsOfExperience = model.YearsOfExperience;
        oldModel.JobLevel = model.JobLevel;
        oldModel.MilitaryStatus = model.MilitaryStatus;
        oldModel.JobShiftPreferred = model.JobShiftPreferred;
        oldModel.DOB = model.DOB;

        await _repo.SaveChangesAsync();
        return oldModel.Id;
    }

    public async Task<Guid> UpdateResume(List<Guid> SelectedLanguages, List<Guid> SelectedSkills, List<string> NewSkills)
    {
        var oldModel = await GetAsync(_storeContext.Applicant!.Id!, false, x => x.ApplicantSkills, x => x.ApplicantLanguages);
        List<Guid> newSkillIds = new List<Guid>();
        if (NewSkills?.Count > 0)
        {
            //oldModel.SelectedSkills ??= new();

            foreach (var skill in NewSkills)
            {
                newSkillIds.Add(await _skillService.CreateAsync(new Skill { Title = skill, IsActive = true }));
            }
        }

        if (oldModel.ApplicantSkills?.Count > 0)
        {
            if (SelectedSkills?.Count > 0)
            {
                var deletedSkills = oldModel.ApplicantSkills.Select(x => x.SkillId).ToList().Except(SelectedSkills).ToList();
                foreach (var applicantSkill in oldModel.ApplicantSkills.Where(x => deletedSkills.Any(y => y == x.SkillId)))
                {
                    await _applicantSkillRepo.DeleteAsync(applicantSkill.Id, false);
                }
            }
            else
            {
                foreach (var applicantSkill in oldModel.ApplicantSkills)
                {
                    await _applicantSkillRepo.DeleteAsync(applicantSkill.Id, false);
                }
            }
        }

        if (oldModel.ApplicantLanguages?.Count > 0)
        {
            if (SelectedLanguages?.Count > 0)
            {
                var deletedLanguages = oldModel.ApplicantLanguages.Select(x => x.LanguageId).ToList().Except(SelectedLanguages).ToList();
                foreach (var applicantLanguage in oldModel.ApplicantLanguages.Where(x => deletedLanguages.Any(y => y == x.LanguageId)))
                {
                    await _applicantLanguageRepo.DeleteAsync(applicantLanguage.Id, false);
                }
            }
            else
            {
                foreach (var applicantLanguage in oldModel.ApplicantLanguages)
                {
                    await _applicantLanguageRepo.DeleteAsync(applicantLanguage.Id, false);
                }
            }
        }

        if(newSkillIds?.Count > 0)
        {
            SelectedSkills ??= new();

            foreach (var skill in newSkillIds)
            {
                SelectedSkills.Add(skill);
            }
        }

        if (SelectedSkills?.Count > 0)
        {
            oldModel.ApplicantSkills ??= new List<ApplicantSkill>();

            foreach (var skill in SelectedSkills)
            {
                if (oldModel.ApplicantSkills.FirstOrDefault(x => x.SkillId == skill) is null)
                {
                    oldModel.ApplicantSkills.Add(new ApplicantSkill { SkillId = skill });
                }
            }
        }

        if (SelectedLanguages?.Count > 0)
        {
            oldModel.ApplicantLanguages ??= new List<ApplicantLanguage>();

            foreach (var language in SelectedLanguages)
            {
                if (oldModel.ApplicantLanguages.FirstOrDefault(x => x.LanguageId == language) is null)
                {
                    oldModel.ApplicantLanguages.Add(new ApplicantLanguage { LanguageId = language });
                }
            }
        }

        await _repo.SaveChangesAsync();
        return oldModel.Id;
    }

    public override async Task<PaginationResponse<Applicant>> PaginateAsync(PaginationFilter<ApplicantSearch> filter)
    {
        filter ??= new();
        Filters<Applicant> filters = new();
        filters.Add(filter.Keyword.HasValue(), x => x.Name.ToLower().Contains(filter.Keyword.ToLower()) ||
                                                    x.Mobile.ToLower().Contains(filter.Keyword.ToLower()) ||
                                                    x.Phone.ToLower().Contains(filter.Keyword.ToLower()));
        PaginationResponse<Applicant> result = await _repo.PaginateAsync(filter, filters);
        return result;
    }

}
