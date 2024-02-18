using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Infrastructure.Services;

public class ExperienceService : BaseService<Experience, ExperienceSearch>, IExperienceService
{
    public ExperienceService(IRepository<Experience> repo)
        : base(repo)
    {
    }
}
