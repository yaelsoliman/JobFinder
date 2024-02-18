using JobFinder.Infrastructure.DbContexts;
using JobFinder.Infrastructure.Identity.Models;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobFinder.Infrastructure.Identity;
public static class SeedUser
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>(), serviceProvider.GetRequiredService<ICurrentUser>());
        var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
        if (!context.Users.Any(x => x.RoleType == RoleType.Admin))
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "superadmin@jobfinder.com",
                PhoneNumber = "0999999999",
                UserName = "SuperAdmin",
                RoleType = RoleType.Admin,
                FullName = "Super Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var res = await userManager.CreateAsync(user, "Test@2023");
        }
    }
}
