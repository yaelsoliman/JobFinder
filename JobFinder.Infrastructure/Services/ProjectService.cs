using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Infrastructure.Services;

public class ProjectService : BaseService<Project, ProjectSearch>, IProjectService
{
    public ProjectService(IRepository<Project> repo)
        : base(repo)
    {
    }
}
