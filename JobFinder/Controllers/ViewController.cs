using JobFinder.Infrastructure.Identity;
using JobFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;
public class ViewController : BaseController
{
    public ViewController(ICurrentUser currentUser) : base(currentUser)
    {
    }

    [HttpGet]
    public IActionResult GetView(ComponentQuery query)
    {
        return ViewComponent(query.Component!, query);
    }

}
