using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class CompaniesController : BaseController
{

    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService, ICurrentUser currentUser)
        :base(currentUser)
    {
        _companyService = companyService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _companyService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<CompanySearch> filter)
    {
        var result = await _companyService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _companyService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> Upsert(Company model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            var createResult = await _companyService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Company Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _companyService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Company Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _companyService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Company Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _companyService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Company Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
