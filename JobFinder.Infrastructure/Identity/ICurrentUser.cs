using JobFinder.Infrastructure.Identity.Models;

namespace JobFinder.Infrastructure.Identity;
public interface ICurrentUser
{
    Guid UserId { get; }
    public string? Username { get; }
}
