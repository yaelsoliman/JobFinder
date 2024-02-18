using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models.ServiceModel;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers;


public class AccountController : BaseController
{

    private readonly IIdentityService _identityService;
    private readonly IStoreContext _storeContext;

    public AccountController(IIdentityService identityService, ICurrentUser currentUser, IStoreContext storeContext) : base(currentUser)
    {
        _identityService = identityService;
        _storeContext = storeContext;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            UserDto user = await _identityService.LoginAsync(request);

            switch (user.RoleType)
            {
                case RoleType.Company:
                    return RedirectToAction("CompanyProfile", "Profile");
                case RoleType.Applicant:
                    return RedirectToAction("ApplicantProfile", "Profile");
                case RoleType.Admin:
                    return RedirectToAction("Companies", "Profile");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        catch (Exception ex)
        {
            if (ex is CustomException)
            {
                return View();
            }
            throw;
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        try
        {
            var origin = Request.Headers["origin"];
            var result = await _identityService.RegisterAsync(request, origin);
            return RedirectToAction(nameof(RegisterCompleted));
        }
        catch (Exception ex)
        {
            if (ex is CustomException)
            {
                return View();
            }
            throw;
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult RegisterCompleted()
    {
        return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
    {
        var origin = Request.Headers["origin"];
        await _identityService.ForgotPassword(model, origin);
        return RedirectToAction(nameof(ForgotPasswordMailSent));
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPasswordMailSent()
    {
        return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
    {
        try
        {
            var result = await _identityService.ResetPassword(model);
            return RedirectToAction(nameof(Login));
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmailAsync(string userId, string code)
    {
        try
        {
            var result = await _identityService.ConfirmEmailAsync(userId, code);
            return RedirectToAction(nameof(Login));
        }
        catch(Exception ex)
        {
            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _identityService.LogoutAsync();
        return RedirectToAction(nameof(Login));
    }

}
