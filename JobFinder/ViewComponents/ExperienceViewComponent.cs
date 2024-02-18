using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Models;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.ViewComponents;

public class ExperienceViewComponent : ViewComponent
{

    private readonly IExperienceService _experienceService;

    public ExperienceViewComponent(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    public async Task<IViewComponentResult> InvokeAsync(ComponentQuery query)
    {
        try
        {
            var id = query.Id;
            return View(query.IsDetails ? "Details" : "UpSert", id is not null ? (await _experienceService.GetAsync(id.Value)) : null);
        }
        catch (Exception)
        {
            throw new CustomException("Component Error");
        }
    }

}
