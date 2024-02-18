using JobFinder.Application.Interfaces.Services;
using JobFinder.Infrastructure.Identity.Models;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace JobFinder.Helper;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RoleCheckAttribute : Attribute, IAuthorizationFilter
{
    public RoleType[] RoleTypes { get; set; }

    public RoleCheckAttribute(params RoleType[] roleTypes)
    {
        RoleTypes = roleTypes;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var serviceProvider = context.HttpContext.RequestServices;
        IIdentityService identityService = serviceProvider.GetRequiredService<IIdentityService>();
        IStoreContext storeContext = serviceProvider.GetRequiredService<IStoreContext>();
        if(storeContext.RoleType is not null && RoleTypes.Length > 0)
        {
            if (!RoleTypes.Contains(storeContext.RoleType.Value))
            {
                context.Result = new RedirectResult("~/Error/Unauthorized");
            }
        }
    }
}
