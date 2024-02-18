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
public class JobsController : BaseController
{

    private readonly IJobService _jobService;
    private readonly ISkillService _skillService;
    private readonly ILanguageService _languageService;

    public JobsController(
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

    [RoleCheck(RoleType.Company, RoleType.Admin)]
    public IActionResult ManageJobs()
    {
        return View();
    }

    [RoleCheck(RoleType.Company)]
    [HttpGet]
    public async Task<IActionResult> PostJob()
    {
        List<Skill> skills = (await _skillService.GetListAsync()).ToList();
        List<Language> languages = (await _languageService.GetListAsync()).ToList();
        ViewBag.Skills = skills;
        ViewBag.Languages = languages;
        return View();
    }

    [RoleCheck(RoleType.Company)]
    [HttpPost]
    public async Task<IActionResult> PostJob(Job model)
    {
        if (_storeContext!.Company is null)
            throw new Exception("Company Not Found");

        model.CompanyId = _storeContext.Company!.Id;
        if (model.Attachments?.Count > 0)
        {
            model.JobAttachments = new List<JobAttachment>();
            foreach (var attachment in model.Attachments)
            {
                var fileExtension = Path.GetExtension(attachment.FileName).ToLower();
                model.JobAttachments.Add(new()
                {
                    AttachmentPath = await _fileService!.UploadFileAsync(attachment, "JobAttachment"),
                    AttachmentType = fileExtension.Equals(".pdf") ? AttachmentType.PDF : AttachmentType.Image,
                    IsActive = model.IsActive
                });
            }
        }
        await _jobService.CreateAsync(model);
        return View();
    }

    [RoleCheck(RoleType.Company)]
    public async Task<IActionResult> GetApplicant(PaginationFilter<ApplicantSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _jobService.GetCompanyApplicant(filter);
        return new JsonResult(result);
    }

    [RoleCheck(RoleType.Company)]
    public IActionResult GetApplicantJob(Guid jobId)
    {
        ViewBag.JobId = jobId;
        return View();
    }

    [RoleCheck(RoleType.Company)]
    public async Task<IActionResult> GetApplicantForJob(PaginationFilter<ApplicantJobSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _jobService.GetApplicantForJob(filter);
        return new JsonResult(result);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _jobService.GetAsync(id, false, x => x.Skills.Select(q => q.Skill), x => x.Languages.Select(q => q.Language), x => x.JobAttachments, x => x.Questions.Select(q => q.JobQuestionAnswers));
        return View(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<JobSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _jobService.PaginateAsync(filter);
        return new JsonResult(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _jobService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> Upsert(Job model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            var createResult = await _jobService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Job Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _jobService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Job Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _jobService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Job Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> BanJob(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _jobService.BanJob(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Job Banned Successfully")) : RedirectToAction(nameof(Index));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _jobService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Job Deleted Successfully")) : RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ApproveApplicant(Guid jobApplicantId)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _jobService.ApproveApplicant(jobApplicantId);
        return isAjaxRequest ? Json(ResponseBool.Success("Job Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> RejectApplicant(Guid jobApplicantId)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _jobService.RejectApplicant(jobApplicantId, "");
        return isAjaxRequest ? Json(ResponseBool.Success("Job Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }
}
