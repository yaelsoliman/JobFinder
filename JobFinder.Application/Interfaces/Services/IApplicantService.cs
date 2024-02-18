using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface IApplicantService : IBaseService<Applicant>, IPaginateService<Applicant, ApplicantSearch>
{
    Task<Guid> UpdateResume(List<Guid> SelectedLanguages, List<Guid> SelectedSkills, List<string> NewSkills);
}
