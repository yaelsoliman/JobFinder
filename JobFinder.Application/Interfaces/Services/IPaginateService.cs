using JobFinder.Application.Models;
using JobFinder.Domain.Common;

namespace JobFinder.Application.Interfaces.Services;

public interface IPaginateService<T, ST>
    where T : BaseEntity
    where ST : class, ISearch
{
    Task<PaginationResponse<T>> PaginateAsync(PaginationFilter<ST> filter);
}
