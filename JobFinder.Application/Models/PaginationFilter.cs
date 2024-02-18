using JobFinder.Application.Common.Extensions;
using JobFinder.Domain.Common;

namespace JobFinder.Application.Models;

public class PaginationFilter<S> :  BaseFilter
    where S : class, ISearch
{

    public PaginationFilter()
    {
        PageNumber = 1;
        PageSize = 10;
        OrderBy = $"{nameof(BaseEntity.CreatedOn)} Desc";
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; } = int.MaxValue;
    public string? OrderBy { get; set; }

    public S? Search { get; set; }
}
