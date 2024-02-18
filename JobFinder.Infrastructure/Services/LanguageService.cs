using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Infrastructure.Services;

public class LanguageService : BaseService<Language, LanguageSearch>, ILanguageService
{
    readonly IRepository<JobLanguage> _jobLanguageRepo;
    readonly IRepository<ApplicantLanguage> _applicantLanguageRepo;

    public LanguageService(IRepository<Language> repo, IRepository<JobLanguage> jobLanguageRepo, IRepository<ApplicantLanguage> applicantLanguageRepo)
        : base(repo)
    {
        _jobLanguageRepo = jobLanguageRepo;
        _applicantLanguageRepo = applicantLanguageRepo;
    }

    public override async Task<PaginationResponse<Language>> PaginateAsync(PaginationFilter<LanguageSearch> filter)
    {
        filter ??= new();
        Filters<Language> filters = new();
        filters.Add(filter.Keyword.HasValue(), x => x.Title.ToLower().Contains(filter.Keyword.ToLower()));
        PaginationResponse<Language> result = await _repo.PaginateAsync(filter, filters);
        return result;
    }

    public override async Task<Guid> DeleteAsync(Guid id)
    {
        var jobLanguages = await _jobLanguageRepo.GetListAsync(x => x.LanguageId == id);
        if (jobLanguages?.Count() > 0)
        {
            foreach (var jobLanguage in jobLanguages)
            {
                await _jobLanguageRepo.DeleteAsync(jobLanguage.Id);
            }
        }
        var applicantLanguages = await _applicantLanguageRepo.GetListAsync(x => x.LanguageId == id);
        if (applicantLanguages?.Count() > 0)
        {
            foreach (var applicantLanguage in applicantLanguages)
            {
                await _applicantLanguageRepo.DeleteAsync(applicantLanguage.Id);
            }
        }
        return await base.DeleteAsync(id);
    }
}
