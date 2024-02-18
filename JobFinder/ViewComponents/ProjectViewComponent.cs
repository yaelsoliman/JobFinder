using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Models;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.ViewComponents;

public class ProjectViewComponent : ViewComponent
{

    private readonly IProjectService _projectService;

    public ProjectViewComponent(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<IViewComponentResult> InvokeAsync(ComponentQuery query)
    {
        try
        {
            var id = query.Id;
            return View(query.IsDetails ? "Details" : "UpSert", id is not null ? (await _projectService.GetAsync(id.Value)) : null);
        }
        catch (Exception)
        {
            throw new CustomException("Component Error");
        }
    }

}
