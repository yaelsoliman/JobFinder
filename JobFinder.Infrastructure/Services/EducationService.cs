using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Infrastructure.Services;

public class EducationService : BaseService<Education, EducationSearch>, IEducationService
{
    public EducationService(IRepository<Education> repo)
        : base(repo)
    {
    }
}
