using JobFinder.Application.Models;
using JobFinder.Domain.Common;
using System.Linq.Expressions;
using System;

namespace JobFinder.Application.Common.Extensions;

public static class QueryExtensions
{
    public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, string? order)
        where T : BaseEntity
    {
        if (order.HasValue())
        {
            var split = order!.Split(" ");
            var orderBy = split[0];
            var sort = split[1];
            var property = typeof(T).GetProperty(orderBy);
            ParameterExpression entityParameter = Expression.Parameter(typeof(T), "e");
            MemberExpression propertyExpression = Expression.Property(entityParameter, orderBy);
            Expression<Func<T, object>> expression = 
                Expression.Lambda<Func<T, object>>(Expression.Convert(propertyExpression, typeof(object)), entityParameter);

            if (sort.ToLower().StartsWith("asc"))
            {
                return query.OrderBy(expression);
            }
            return query.OrderByDescending(expression);
        }
        return query;
    }


    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Filters<T> filters)
        where T : BaseEntity
    {
        var results = !filters.IsValid() ? query : filters.Get().Aggregate(query, (current, filter) => filter.Expression is null ? current : current.Where(filter.Expression));
        return results;
    }
}
