using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class SkillsController : BaseController
{

    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService, ICurrentUser currentUser)
        :base(currentUser)
    {
        _skillService = skillService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _skillService.GetAsync(id);
        return View(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<SkillSearch> filter)
    {
        if (filter.Search is null) filter.Search = new();
        var result = await _skillService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _skillService.GetAsync(id);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Skill model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        model.IsActive = true;
        var createResult = await _skillService.CreateAsync(model);
        return isAjaxRequest ? Json(new BaseResponse<Skill>("Skill Created Successfully") { Data = model, Succeeded = true }) : RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Upsert(Skill model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id == Guid.Empty)
        {
            var createResult = await _skillService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Skill Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _skillService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Skill Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _skillService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Skill Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _skillService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Skill Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
