using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface IEducationService : IBaseService<Education>, IPaginateService<Education, EducationSearch>
{
}
