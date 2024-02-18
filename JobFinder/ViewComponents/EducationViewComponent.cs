using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Models;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.ViewComponents;

public class EducationViewComponent : ViewComponent
{

    private readonly IEducationService _educationService;

    public EducationViewComponent(IEducationService educationService)
    {
        _educationService = educationService;
    }

    public async Task<IViewComponentResult> InvokeAsync(ComponentQuery query)
    {
        try
        {
            var id = query.Id;
            return View(query.IsDetails ? "Details" : "UpSert", id is not null ? (await _educationService.GetAsync(id.Value)) : null);
        }
        catch (Exception)
        {
            throw new CustomException("Component Error");
        }
    }

}
