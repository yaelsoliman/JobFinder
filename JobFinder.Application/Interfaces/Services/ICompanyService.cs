using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface ICompanyService : IBaseService<Company>, IPaginateService<Company, CompanySearch>
{
    Task<Guid> CustomUpdateAsync(Company model);
}
