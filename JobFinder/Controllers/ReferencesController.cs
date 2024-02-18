using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Services;
using JobFinder.Infrastructure.Store;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class ReferencesController : BaseController
{

    private readonly IReferenceService _referenceService;

    public ReferencesController(IReferenceService referenceService, ICurrentUser currentUser, IStoreContext storeContext)
        : base(currentUser, storeContext)
    {
        _referenceService = referenceService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _referenceService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<ReferenceSearch> filter)
    {
        var result = await _referenceService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _referenceService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> Upsert(Reference model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            var createResult = await _referenceService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Reference Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _referenceService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Reference Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _referenceService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Reference Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Reference model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        model.ApplicantId = _storeContext!.Applicant!.Id;
        var createResult = await _referenceService.CreateAsync(model);
        return isAjaxRequest ? Json(new BaseResponse<Reference>("Reference Created Successfully") { Data = model, Succeeded = true }) : RedirectToAction(nameof(Index));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _referenceService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Reference Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
