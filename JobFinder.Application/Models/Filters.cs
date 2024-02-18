using JobFinder.Domain.Common;
using System.Linq.Expressions;

namespace JobFinder.Application.Models;

public class Filter<T>
{
    public bool Condition { get; set; }
    public Expression<Func<T, bool>>? Expression { get; set; }
}

//important Only used for paginate from database entities
public class Filters<T>
    where T : BaseEntity
{
    private readonly List<Filter<T>> _filterList;
    public Filters()
    {
        _filterList = new List<Filter<T>>();
    }

    public void Add(bool condition, Expression<Func<T, bool>> expression)
    {
        _filterList.Add(new Filter<T>
        {
            Condition = condition,
            Expression = expression
        });
    }

    public bool IsValid()
    {
        return _filterList.Any(f => f.Condition);
    }

    public List<Filter<T>> Get()
    {
        return _filterList.Where(f => f.Condition).ToList();
    }
}