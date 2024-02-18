using JobFinder.Application.Interfaces.Services;
using JobFinder.Domain.Common;
using JobFinder.Helper;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Shared;
using JobFinder.Infrastructure.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;

[Authorize]
public class BaseController : Controller
{
    protected readonly ICurrentUser _currentUser;
    protected readonly IStoreContext? _storeContext;
    protected readonly IFileService? _fileService;

    public BaseController(ICurrentUser currentUser, IStoreContext storeContext)
    {
        _currentUser = currentUser;
        _storeContext = storeContext;
    }

    public BaseController(ICurrentUser currentUser, IStoreContext storeContext, IFileService fileService)
    {
        _currentUser = currentUser;
        _storeContext = storeContext;
        _fileService = fileService;
    }

    public BaseController(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public BaseController(ICurrentUser currentUser, IFileService fileService)
    {
        _currentUser = currentUser;
        _fileService = fileService;
    }
}
