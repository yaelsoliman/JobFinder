using JobFinder.Shared.Common;

namespace JobFinder.Models;

public class ComponentQuery
{
    public string? Component { get; set; }
    public Guid? Id { get; set; }
    public bool IsDetails { get; set; }
}