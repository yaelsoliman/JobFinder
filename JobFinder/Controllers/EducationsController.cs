using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Store;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class EducationsController : BaseController
{

    private readonly IEducationService _educationService;

    public EducationsController(IEducationService educationService, ICurrentUser currentUser, IStoreContext storeContext)
        : base(currentUser, storeContext)
    {
        _educationService = educationService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _educationService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<EducationSearch> filter)
    {
        var result = await _educationService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _educationService.GetAsync(id);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Education model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        model.ApplicantId = _storeContext!.Applicant!.Id;
        var createResult = await _educationService.CreateAsync(model);
        return isAjaxRequest ? Json(new BaseResponse<Education>("Education Created Successfully") { Data = model, Succeeded = true }) : RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Upsert(Education model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            model.ApplicantId = _storeContext!.Applicant!.Id;
            var createResult = await _educationService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Education Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _educationService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Education Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _educationService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Education Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _educationService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Education Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
