using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Models;
using JobFinder.Domain.Common;
using JobFinder.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobFinder.Infrastructure.Repository;
public class Repository<T> : IRepository<T>
    where T : BaseEntity
{

    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> _set;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _set = dbContext.Set<T>();
    }

    public async Task<T?> FindAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        T? entity;
        if (includes?.Length > 0)
        {
            var set = _set.AsQueryable();
            foreach (var include in includes)
                set = set.Include(include);

            entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        }
        else
        {
            entity = await _set.FindAsync(id);

        }

        return entity;
    }

    public async Task<T?> FirstOrDefaultAsync(params Expression<Func<T, object>>[] includes)
    {
        T? entity;
        var set = _set.AsQueryable();

        if (includes?.Length > 0)
        {
            foreach (var include in includes)
                set = set.Include(include);
        }

        entity = await set.FirstOrDefaultAsync();
        return entity;
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
    {
        T? entity;
        var set = _set.AsTracking().AsQueryable();

        if (includes?.Length > 0)
        {
            foreach (var include in includes)
                set = set.Include(include);
        }

        entity = await set.FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<IEnumerable<T>?> GetListAsync(params Expression<Func<T, object>>[] includes)
    {
        IEnumerable<T>? entities;
        var set = _set.AsQueryable();

        if (includes?.Length > 0)
        {
            foreach (var include in includes)
                set = set.Include(include);
        }

        entities = await set.ToListAsync();
        return entities;
    }

    public async Task<IEnumerable<T>?> GetListAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
    {
        IEnumerable<T>? entities;
        var set = _set.AsTracking().AsQueryable();

        if (includes?.Length > 0)
        {
            foreach (var include in includes)
                set = set.Include(include);
        }

        entities = await set.Where(expression).ToListAsync();
        return entities;
    }

    public async Task<PaginationResponse<T>> PaginateAsync<S>(PaginationFilter<S> paginationFilter, Filters<T> filters, Expression<Func<T, object>>? distinctBy = null, params Expression<Func<T, object>>[] includes)
        where S : class, ISearch
    {
        if (paginationFilter.Search is null)
            throw new NullableException($"Search of {typeof(T).Name} must not be null");

        var set = _set.AsQueryable();

        if (paginationFilter.PageNumber <= 0)
        {
            paginationFilter.PageNumber = 1;
        }

        if (paginationFilter.PageSize <= 0)
        {
            paginationFilter.PageSize = int.MaxValue;
        }

        set = set.ApplyFilter(filters);
        set = set.ApplySort(paginationFilter.OrderBy);
        if (includes?.Length > 0)
        {
            foreach (var include in includes)
                set = set.Include(include);
        }
        if (distinctBy is not null)
        {
            set = set.GroupBy(distinctBy).Select(g => g.First());
        }

        if (paginationFilter.PageNumber > 1)
        {
            set = set.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize);
        }

        set = set.Take(paginationFilter.PageSize);


        var list = await set.ToListAsync();
        var count = await _set.ApplyFilter(filters).CountAsync();

        return new PaginationResponse<T>(list, count, paginationFilter.PageNumber, paginationFilter.PageSize);
    }

    public async Task<Guid> CreateAsync(T model)
    {
        var result = await _set.AddAsync(model);
        await _dbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<Guid> UpdateAsync(T model)
    {
        _dbContext.Entry(model).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return model.Id;
    }

    public async Task<Guid> ToggleActiveAsync(Guid id)
    {
        T? entity = await _set.AsTracking().FirstOrDefaultAsync(x=>x.Id == id);
        if (entity is not null)
        {
            entity.IsActive = !entity.IsActive;
            await _dbContext.SaveChangesAsync();
            return id;
        }
        throw new NotFoundException(string.Format("{0} List Not Found.", typeof(T).Name));
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        T? entity = await FindAsync(id);
        if (entity is not null)
        {
            entity.DeleteName = "deleted";
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return id;
        }
        throw new NotFoundException(string.Format("{0} List Not Found.", typeof(T).Name));
    }

    public async Task<Guid> DeleteAsync(Guid id, bool saveChanges)
    {
        T? entity = await FindAsync(id);
        if (entity is not null)
        {
            entity.DeleteName = "deleted";
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (saveChanges)
                await _dbContext.SaveChangesAsync();

            return id;
        }
        throw new NotFoundException(string.Format("{0} List Not Found.", typeof(T).Name));
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> DistinctBy(Expression<Func<T, object>> expression)
    {
        var set = _set.AsQueryable();
        set = set.DistinctBy(expression);
        return set;
    }
}
