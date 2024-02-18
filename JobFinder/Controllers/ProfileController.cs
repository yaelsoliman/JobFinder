using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Helper;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Shared;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobFinder.Controllers;
public class ProfileController : BaseController
{

    private readonly ICompanyService _companyService;
    private readonly IApplicantService _applicantService;
    private readonly ILanguageService _languageService;
    private readonly ISkillService _skillService;
    private readonly IJobService _jobService;

    public ProfileController(
        ICompanyService companyService,
        IApplicantService applicantService,
        ILanguageService languageService,
        ISkillService skillService,
        IJobService jobService,
        ICurrentUser currentUser,
        IStoreContext storeContext,
        IFileService fileService)
        : base(currentUser, storeContext, fileService)
    {
        _companyService = companyService;
        _applicantService = applicantService;
        _languageService = languageService;
        _skillService = skillService;
        _jobService = jobService;
    }

    public async Task<IActionResult> CompanyProfile()
    {
        var profile = await _companyService.GetAsync(_storeContext!.Company!.Id!, includes: x => x.Galleries);
        return View(profile);
    }

    [RoleCheck(RoleType.Admin)]
    public IActionResult Companies()
    {
        return View();
    }

    [RoleCheck(RoleType.Admin)]
    public async Task<IActionResult> GetCompanies(PaginationFilter<CompanySearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _companyService.PaginateAsync(filter);
        return Json(result);
    }

    [RoleCheck(RoleType.Admin)]
    public IActionResult Jobs()
    {
        return View();
    }

    [RoleCheck(RoleType.Admin)]
    public async Task<IActionResult> GetJobs(PaginationFilter<JobSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _jobService.PaginateAsync(filter);
        return Json(result);
    }

    [RoleCheck(RoleType.Admin)]
    public IActionResult Applicants()
    {
        return View();
    }

    [RoleCheck(RoleType.Admin)]
    public async Task<IActionResult> GetApplicants(PaginationFilter<ApplicantSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _applicantService.PaginateAsync(filter);
        return Json(result);
    }

    [HttpGet]
    public async Task<IActionResult> EditCompanyProfile()
    {
        var profile = await _companyService.GetAsync(_storeContext!.Company!.Id!, includes: x => x.Galleries);
        return View(profile);
    }

    [HttpPost]
    public async Task<IActionResult> EditCompanyProfile(Company model)
    {
        if (model.LogoFile is not null)
        {
            model.Logo = await _fileService!.UploadFileAsync(model.LogoFile, nameof(Company));
        }
        if (model.GalleryFiles?.Count > 0)
        {
            model.Galleries ??= new List<CompanyGallery>();

            foreach (var file in model.GalleryFiles)
            {
                var filePath = await _fileService!.UploadFileAsync(file, nameof(Company));
                model.Galleries.Add(new CompanyGallery
                {
                    CompanyId = _storeContext!.Company!.Id!,
                    Image = filePath,
                });
            }
        }
        var result = await _companyService.CustomUpdateAsync(model);
        return RedirectToAction(nameof(CompanyProfile));
    }

    public async Task<IActionResult> ApplicantProfile()
    {
        var profile = await _applicantService.GetAsync(_storeContext!.Applicant!.Id!);
        return View(profile);
    }

    public async Task<IActionResult> ShowApplicantProfile(Guid id)
    {
        var profile = await _applicantService.GetAsync(id);
        return View(profile);
    }

    public async Task<IActionResult> ShowCompanyProfile(Guid id)
    {
        var profile = await _companyService.GetAsync(id, includes: x => x.Galleries);
        return View(profile);
    }


    [HttpGet]
    public async Task<IActionResult> EditApplicantProfile()
    {
        var profile = await _applicantService.GetAsync(_storeContext!.Applicant!.Id!);
        profile.Day = profile.DOB.Day;
        profile.Month = profile.DOB.Month;
        profile.Year = profile.DOB.Year;
        return View(profile);
    }

    [HttpPost]
    public async Task<IActionResult> EditApplicantProfile(Applicant model)
    {
        if (model.ImageFile is not null)
        {
            model.Image = await _fileService!.UploadFileAsync(model.ImageFile, nameof(Applicant));
        }

        model.DOB = new DateTime(model.Year, model.Month, model.Day);

        var result = await _applicantService.UpdateAsync(model);
        return RedirectToAction(nameof(ApplicantProfile));
    }

    public async Task<IActionResult> ApplicantResume()
    {
        var profile = await _applicantService.GetAsync(_storeContext!.Applicant!.Id!, false,
            x => x.ApplicantSkills,
            x => x.ApplicantLanguages,
            x => x.Educations,
            x => x.Certificates,
            x => x.Experiences,
            x => x.Projects,
            x => x.References);

        ViewBag.Languages = await _languageService.GetListAsync(x => x.IsActive == true);
        ViewBag.Skills = await _skillService.GetListAsync(x => x.IsActive == true);

        return View(profile);
    }

    public async Task<IActionResult> ShowApplicantResume(Guid id)
    {
        var profile = await _applicantService.GetAsync(id, false,
            x => x.ApplicantSkills,
            x => x.ApplicantLanguages,
            x => x.Educations,
            x => x.Certificates,
            x => x.Experiences,
            x => x.Projects,
            x => x.References);

        if (profile.ApplicantLanguages?.Count > 0)
        {
            foreach (var applicantLanguage in profile.ApplicantLanguages)
            {
                applicantLanguage.Language = await _languageService.GetAsync(applicantLanguage.LanguageId);
            }
        }
        if (profile.ApplicantSkills?.Count > 0)
        {
            foreach (var applicantSkill in profile.ApplicantSkills)
            {
                applicantSkill.Skill = await _skillService.GetAsync(applicantSkill.SkillId);
            }
        }

        return View(profile);
    }

    [HttpPost]
    public async Task<IActionResult> EditApplicantResume(List<Guid> SelectedLanguages, List<Guid> SelectedSkills, List<string> NewSkills)
    {
        var xx = await _applicantService.UpdateResume(SelectedLanguages, SelectedSkills, NewSkills);
        return RedirectToAction(nameof(ApplicantResume));
    }
}
