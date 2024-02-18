using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Helper;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Shared;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class ApplicantsController : BaseController
{

    private readonly IJobService _jobService;
    private readonly ISkillService _skillService;
    private readonly ILanguageService _languageService;

    public ApplicantsController(
        IJobService jobService,
        ISkillService skillService,
        ILanguageService languageService,
        ICurrentUser currentUser,
        IStoreContext storeContext,
        IFileService fileService)
        : base(currentUser, storeContext, fileService)
    {
        _jobService = jobService;
        _skillService = skillService;
        _languageService = languageService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [RoleCheck(RoleType.Company)]
    public IActionResult CompanyApplicants()
    {
        return View();
    }

    [RoleCheck(RoleType.Applicant)]
    public IActionResult AppliedJob()
    {
        return View();
    }

    [RoleCheck(RoleType.Company)]
    public async Task<IActionResult> GetCompanyApplicant(PaginationFilter<ApplicantSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _jobService.GetCompanyApplicant(filter);
        return new JsonResult(result);
    }

    [RoleCheck(RoleType.Applicant)]
    public async Task<IActionResult> GetAppliedJob(PaginationFilter<ApplicantSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _jobService.GetAppliedJob(filter);
        return new JsonResult(result);
    }
}
