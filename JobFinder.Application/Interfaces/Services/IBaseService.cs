using JobFinder.Domain.Common;
using System.Linq.Expressions;

namespace JobFinder.Application.Interfaces.Services;

public interface IBaseService<T>
    where T : BaseEntity
{
    Task<T> FirstOrDefault(params Expression<Func<T, object>>[] includes);
    Task<T> GetAsync(Guid id, bool asTracking = false, params Expression<Func<T, object>>[] includes);
    Task<T> GetAsync(bool asTracking = false, params Expression<Func<T, object>>[] includes);
    Task<T> GetAsync(Expression<Func<T, bool>> expression, bool asTracking = false, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetListAsync(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression, bool asTracking = false, params Expression<Func<T, object>>[] includes);
    Task<Guid> CreateAsync(T model);
    Task<Guid> UpdateAsync(T model);
    Task<Guid> ToggleActive(Guid id);
    Task<Guid> DeleteAsync(Guid id);
}
