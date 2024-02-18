using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Services;
using JobFinder.Infrastructure.Store;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class ExperiencesController : BaseController
{

    private readonly IExperienceService _experienceService;

    public ExperiencesController(IExperienceService experienceService, ICurrentUser currentUser, IStoreContext storeContext)
        : base(currentUser, storeContext)
    {
        _experienceService = experienceService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _experienceService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<ExperienceSearch> filter)
    {
        var result = await _experienceService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _experienceService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> Upsert(Experience model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            var createResult = await _experienceService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Experience Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _experienceService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Experience Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _experienceService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Experience Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Experience model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        model.ApplicantId = _storeContext!.Applicant!.Id;
        var createResult = await _experienceService.CreateAsync(model);
        return isAjaxRequest ? Json(new BaseResponse<Experience>("Experience Created Successfully") { Data = model, Succeeded = true }) : RedirectToAction(nameof(Index));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _experienceService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Experience Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
