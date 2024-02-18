using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;
using JobFinder.Extensions;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Store;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class ProjectsController : BaseController
{

    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService, ICurrentUser currentUser, IStoreContext storeContext)
        :base(currentUser, storeContext)
    {
        _projectService = projectService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _projectService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> GetListAsync(PaginationFilter<ProjectSearch> filter)
    {
        var result = await _projectService.PaginateAsync(filter);
        return Json(result);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _projectService.GetAsync(id);
        return Json(result);
    }

    public async Task<IActionResult> Upsert(Project model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        if (model.Id != Guid.Empty)
        {
            var createResult = await _projectService.CreateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Project Created Successfully")) : RedirectToAction(nameof(Index));
        }
        else
        {
            var updateResult = await _projectService.UpdateAsync(model);
            return isAjaxRequest ? Json(ResponseBool.Success("Project Updated Successfully")) : RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> ToggleActive(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _projectService.ToggleActive(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Project Status Changed Successfully")) : RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public async Task<IActionResult> Create(Project model)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        model.ApplicantId = _storeContext!.Applicant!.Id;
        var createResult = await _projectService.CreateAsync(model);
        return isAjaxRequest ? Json(new BaseResponse<Project>("Project Created Successfully") { Data = model, Succeeded = true }) : RedirectToAction(nameof(Index));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isAjaxRequest = Request.IsAjaxRequest();
        var result = await _projectService.DeleteAsync(id);
        return isAjaxRequest ? Json(ResponseBool.Success("Project Deleted Successfully")) : RedirectToAction(nameof(Index));
    }
}
