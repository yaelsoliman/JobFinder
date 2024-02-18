using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface IProjectService : IBaseService<Project>, IPaginateService<Project, ProjectSearch>
{
}
