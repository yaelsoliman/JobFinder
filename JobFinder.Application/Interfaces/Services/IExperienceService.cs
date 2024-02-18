using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface IExperienceService : IBaseService<Experience>, IPaginateService<Experience, ExperienceSearch>
{
}
