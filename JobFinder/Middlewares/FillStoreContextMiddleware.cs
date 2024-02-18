using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models.ServiceModel;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;
using System.Security.Claims;

namespace JobFinder.Middlewares;

public class FillStoreContextMiddleware
{
    private readonly RequestDelegate _next;

    public FillStoreContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context,
        IHttpContextAccessor httpContextAccessor,
        IIdentityService identityService,
        ICompanyService companyService,
        IApplicantService applicantService,
        IStoreContext storeContext)
    {
        string? currentUserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier) == null ? null : httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (currentUserId.HasValue())
        {
            UserDto? userDto = await identityService.GetUserByIdAsync(currentUserId!);
            storeContext.CurrentUser = userDto;
            storeContext.RoleType = userDto?.RoleType;
            if (userDto?.RoleType is not null && userDto?.RoleType == RoleType.Company)
            {
                var company = await companyService.GetAsync(x => x.ApplicationUserId == Guid.Parse(userDto.Id!));
                storeContext.Company = company;
            }
            if (userDto?.RoleType is not null && userDto?.RoleType == RoleType.Applicant)
            {
                var applicant = await applicantService.GetAsync(x => x.ApplicationUserId == Guid.Parse(userDto.Id!), false, x=>x.ApplicantSkills, x => x.ApplicantLanguages);
                storeContext.Applicant = applicant;
            }
        }

        await _next(context);
        // Do something with the response
    }
}
