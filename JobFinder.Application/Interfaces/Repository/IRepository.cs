using JobFinder.Application.Models;
using JobFinder.Domain.Common;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace JobFinder.Application.Interfaces.Repository;
public interface IRepository<T>
    where T : BaseEntity
{
    Task<T?> FindAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<T?> FirstOrDefaultAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>?> GetListAsync(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>?> GetListAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    Task<PaginationResponse<T>> PaginateAsync<S>(PaginationFilter<S> paginationFilter, Filters<T> filters, Expression<Func<T, object>>? distinctBy = null, params Expression<Func<T, object>>[] includes) where S: class, ISearch;
    Task<Guid> CreateAsync(T model);
    Task<Guid> UpdateAsync(T model);
    Task<Guid> ToggleActiveAsync(Guid id);
    Task<Guid> DeleteAsync(Guid id);
    Task<Guid> DeleteAsync(Guid id, bool saveChanges);
    Task SaveChangesAsync();
}