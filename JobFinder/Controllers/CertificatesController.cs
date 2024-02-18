using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Services;
using JobFinder.Infrastructure.Store;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class CertificatesController : BaseController
{

    private readonly ICertificateService _certificateService;

    public CertificatesController(ICertificateService certificateService, ICurrentUser currentUser, IStoreContext storeContext)
        :base(currentUser, storeContext)
    {
        _certificateService = certificateService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _certificateService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<CertificateSearch> filter)
    {
        var result = await _certificateService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _certificateService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> Upsert(Certificate model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            var createResult = await _certificateService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Certificate Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _certificateService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Certificate Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _certificateService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Certificate Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Certificate model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        model.ApplicantId = _storeContext!.Applicant!.Id;
        var createResult = await _certificateService.CreateAsync(model);
        return isAjaxRequest ? Json(new BaseResponse<Certificate>("Certificate Created Successfully") { Data = model, Succeeded = true }) : RedirectToAction(nameof(Index));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _certificateService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Certificate Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
