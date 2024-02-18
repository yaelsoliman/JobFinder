using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class LanguagesController : BaseController
{

    private readonly ILanguageService _languageService;

    public LanguagesController(ILanguageService languageService, ICurrentUser currentUser)
        :base(currentUser)
    {
        _languageService = languageService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _languageService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<LanguageSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _languageService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _languageService.GetAsync(id);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Language model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        model.IsActive = true;
        var createResult = await _languageService.CreateAsync(model);
        return isAjaxRequest ? Json(new BaseResponse<Language>("Language Created Successfully") { Data = model, Succeeded = true }) : RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Upsert(Language model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            var createResult = await _languageService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Language Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _languageService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Language Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _languageService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Language Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _languageService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Language Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
