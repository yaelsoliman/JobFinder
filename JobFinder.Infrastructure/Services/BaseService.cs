using Azure.Core;
using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Common;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;


namespace JobFinder.Infrastructure.Services;
public class BaseService<T, ST> : IBaseService<T>, IPaginateService<T, ST>
    where T : BaseEntity
    where ST : class, ISearch
{

    protected readonly IRepository<T> _repo;

    public BaseService(IRepository<T> repo)
    {
        _repo = repo;
    }

    public virtual async Task<T> FirstOrDefault(params Expression<Func<T, object>>[] includes)
    {
        T? result = await _repo.FirstOrDefaultAsync(includes);
        _ = result ?? throw new NotFoundException(string.Format("{0} Not Found.", typeof(T).Name));

        return result;
    }

    public virtual async Task<T> GetAsync(bool asTracking = false, params Expression<Func<T, object>>[] includes)
    {
        T? result = await _repo.FirstOrDefaultAsync(includes);
        _ = result ?? throw new NotFoundException(string.Format("{0} Not Found.", typeof(T).Name));

        return result;
    }

    public virtual async Task<T> GetAsync(Guid id, bool asTracking = false, params Expression<Func<T, object>>[] includes)
    {
        T? result = await _repo.FindAsync(id, includes);
        _ = result ?? throw new NotFoundException(string.Format("{0} Not Found.", typeof(T).Name));

        return result;
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool asTracking = false, params Expression<Func<T, object>>[] includes)
    {
        T? result = await _repo.FirstOrDefaultAsync(expression, includes);
        _ = result ?? throw new NotFoundException(string.Format("{0} Not Found.", typeof(T).Name));

        return result;
    }

    public virtual async Task<IEnumerable<T>> GetListAsync(params Expression<Func<T, object>>[] includes)
    {
        IEnumerable<T>? result = await _repo.GetListAsync(includes);
        _ = result ?? throw new NotFoundException(string.Format("{0} List Not Found.", typeof(T).Name));

        return result;
    }

    public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression, bool asTracking = false, params Expression<Func<T, object>>[] includes)
    {
        IEnumerable<T>? result = await _repo.GetListAsync(expression, includes);
        _ = result ?? throw new NotFoundException(string.Format("{0} List Not Found.", typeof(T).Name));

        return result;
    }

    public virtual async Task<PaginationResponse<T>> PaginateAsync(PaginationFilter<ST> filter)
    {
        filter ??= new();
        Filters<T> filters = new();
        if(filter.Search is not null)
        {

        }
        PaginationResponse<T> result = await _repo.PaginateAsync(filter, filters);
        return result;
    }

    public virtual async Task<Guid> CreateAsync(T model)
    {
        var result = await _repo.CreateAsync(model);
        return result;
    }

    public virtual async Task<Guid> UpdateAsync(T model)
    {
        var oldModel = await GetAsync(model.Id);
        var baseEntityProperties= new BaseEntity().GetType().GetProperties().Where(x => x.Name != nameof(BaseEntity.IsActive));
        foreach (var property in model.GetType().GetProperties().ToList().Except(baseEntityProperties))
        {
            oldModel.GetType().GetProperty(property.Name)?.SetValue(oldModel, property.GetValue(model));
        }
        var result = await _repo.UpdateAsync(model);
        return result;
    }

    public virtual async Task<Guid> ToggleActive(Guid id)
    {
        var result = await _repo.ToggleActiveAsync(id);
        return result;
    }

    public virtual async Task<Guid> DeleteAsync(Guid id)
    {
        var result = await _repo.DeleteAsync(id);
        return result;
    }
}
