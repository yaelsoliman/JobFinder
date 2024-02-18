using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Infrastructure.Services;

public class SkillService : BaseService<Skill, SkillSearch>, ISkillService
{

    readonly IRepository<JobSkill> _jobSkillRepo;
    readonly IRepository<ApplicantSkill> _applicantSkillRepo;

    public SkillService(IRepository<Skill> repo, IRepository<JobSkill> jobSkillRepo, IRepository<ApplicantSkill> applicantSkillRepo)
        : base(repo)
    {
        _jobSkillRepo = jobSkillRepo;
        _applicantSkillRepo = applicantSkillRepo;
    }

    public override async Task<PaginationResponse<Skill>> PaginateAsync(PaginationFilter<SkillSearch> filter)
    {
        filter ??= new();
        Filters<Skill> filters = new();
        filters.Add(filter.Keyword.HasValue(), x => x.Title.ToLower().Contains(filter.Keyword.ToLower()));
        PaginationResponse<Skill> result = await _repo.PaginateAsync(filter, filters);
        return result;
    }

    public override async Task<Guid> DeleteAsync(Guid id)
    {
        var jobSkills = await _jobSkillRepo.GetListAsync(x => x.SkillId == id);
        if(jobSkills?.Count() > 0)
        {
            foreach(var jobSkill in jobSkills)
            {
                await _jobSkillRepo.DeleteAsync(jobSkill.Id);
            }
        }
        var applicantSkills = await _applicantSkillRepo.GetListAsync(x => x.SkillId == id);
        if (applicantSkills?.Count() > 0)
        {
            foreach (var applicantSkill in applicantSkills)
            {
                await _applicantSkillRepo.DeleteAsync(applicantSkill.Id);
            }
        }
        return await base.DeleteAsync(id);
    }
}
