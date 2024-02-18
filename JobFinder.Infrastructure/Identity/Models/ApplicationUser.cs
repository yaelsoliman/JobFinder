using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Identity;

namespace JobFinder.Infrastructure.Identity.Models;
public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public string? Image { get; set; }
    public RoleType RoleType { get; set; }
}
