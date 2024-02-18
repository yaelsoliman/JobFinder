using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Models;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.ViewComponents;

public class SkillViewComponent : ViewComponent
{
    public SkillViewComponent()
    {
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }

}
