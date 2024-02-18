using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Application.Models.ServiceModel;
using JobFinder.Domain.Entities;
using JobFinder.Helper;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Store;
using JobFinder.Models;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobFinder.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IJobService _jobService;
    readonly ISkillService _skillService;
    readonly ILanguageService _languageService;

    public HomeController(
        ILogger<HomeController> logger,
        ICurrentUser currentUser, 
        IStoreContext storeContext, 
        IJobService jobService,
        ISkillService skillService,
        ILanguageService languageService)
        : base(currentUser, storeContext)
    {
        _logger = logger;
        _jobService = jobService;
        _skillService = skillService;
        _languageService = languageService;
    }

    [RoleCheck(RoleType.Applicant, RoleType.Admin, RoleType.Company)]
    public async Task<IActionResult> Index()
    {
        //if(!_storeContext.RoleType.Equals(RoleType.Applicant))
        //    return RedirectToAction("Index", "Profile");
        if(_storeContext is not null && _storeContext.CurrentUser is not null)
        {
            switch (_storeContext.CurrentUser.RoleType)
            {
                case RoleType.Company:
                    return RedirectToAction("CompanyProfile", "Profile");
                case RoleType.Admin:
                    return RedirectToAction("Companies", "Profile");
            }
        }

        ViewBag.Skills = (await _skillService.GetListAsync(x => x.IsActive == true))?.ToList();
        ViewBag.Languages = (await _languageService.GetListAsync(x => x.IsActive == true))?.ToList();

        return View();
    }

    [RoleCheck(RoleType.Applicant)]
    [HttpPost]
    public async Task<IActionResult> GetJobs(PaginationFilter<JobSearch> filter)
    {
        var result = await _jobService.GetJobsForApplicant(filter);
        return Json(result);
    }

    [RoleCheck(RoleType.Applicant)]
    [HttpGet]
    public async Task<IActionResult> JobDetails(Guid id)
    {
        var result = await _jobService.GetAsync(id);
        return View(result);
    }

    [RoleCheck(RoleType.Applicant)]
    [HttpGet]
    public async Task<IActionResult> ApplyForJob(Guid id)
    {
        var job = await _jobService.GetAsync(id);
        if(job is not null && _storeContext?.Applicant is not null)
        {
            var jobApplicantId = await _jobService.ApplyForJob(job.Id, _storeContext.Applicant.Id);
            if (job.HasOnlineTest)
            {
                return View(job);
            }
        }
        return RedirectToAction(nameof(JobDetails), new { id = job.Id });
    }

    [RoleCheck(RoleType.Applicant)]
    [HttpPost]
    public async Task<IActionResult> SubmitTest(SubmitTestRequest request)
    {
        var result = await _jobService.SubmitTest(request.JobId, request.ApplyJobRequest);
        return Json(ResponseBool.Success("Done"));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
