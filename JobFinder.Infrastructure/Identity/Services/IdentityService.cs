using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Exceptions;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Interfaces.Shared;
using JobFinder.Application.Models.ServiceModel;
using JobFinder.Domain.Entities;
using JobFinder.Infrastructure.Identity.Models;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace JobFinder.Infrastructure.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ICompanyService _companyService;
    private readonly IApplicantService _applicantService;
    private readonly IMailService _mailService;

    public IdentityService(
        UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager, 
        ICompanyService companyService,
        IApplicantService applicantService,
        IMailService mailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _companyService = companyService;
        _applicantService = applicantService;
        _mailService = mailService;
    }

    public async Task<UserDto> LoginAsync(LoginRequest request)
    {
        if(request is null)
            throw new CustomException("Email and password is required!");

        if (request.Email is null)
            throw new CustomException("Email is required!");

        if (request.Password is null)
            throw new CustomException("Password is required!");

        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email) ?? throw new CustomException("No user found with this email!");
        
        var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
        
        if(!result.Succeeded)
            throw new CustomException("Incorrect email or password!");

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = user.FullName,
            Image = user.Image,
            RoleType = user.RoleType,
        };
    }

    public async Task<string> RegisterAsync(RegisterRequest request, string origin)
    {
        if(request.UserName.IsEmpty())
            throw new CustomException($"Username is required!");

        if (request.Email.IsEmpty())
            throw new CustomException($"Email is required!");

        if (request.Password.IsEmpty())
            throw new CustomException($"Password is required!");

        if (request.ConfirmPassword.IsEmpty())
            throw new CustomException($"Confirm Password is required!");

        if (request.ConfirmPassword != request.Password)
            throw new CustomException($"Password Not Match!");

        var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName!);
        if (userWithSameUserName != null)
        {
            throw new CustomException($"Username '{request.UserName}' is already taken.");
        }

        var user = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            FullName = string.Concat(request.FirstName, " ", request.LastName).Trim(),
            UserName = request.UserName,
            RoleType = request.RoleType,
        };

        var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email!);
        if (userWithSameEmail == null)
        {
            var result = await _userManager.CreateAsync(user, request.Password!);
            if (result.Succeeded)
            {
                if (request.RoleType.Equals(RoleType.Company))
                {
                    var companyId = await _companyService.CreateAsync(new Company 
                    {
                        Email = request.Email,
                        ApplicationUserId = Guid.Parse(user.Id),
                        Name = user.FullName.Trim(),
                    });
                }
                if (request.RoleType.Equals(RoleType.Applicant))
                {
                    var companyId = await _applicantService.CreateAsync(new Applicant
                    {
                        Email = request.Email,
                        ApplicationUserId = Guid.Parse(user.Id),
                        Name = user.FullName.Trim(),
                    });
                }
                var verificationUri = await SendVerificationEmail(user, origin);
                Console.Write(verificationUri);
                await _mailService.SendAsync(new MailRequest() { To = user.Email, Body = $"Please confirm your account by <a href='{verificationUri}'>clicking here</a>.", Subject = "Confirm Registration" });
                return user.Id;
            }
            else
            {
                throw new CustomException($"{result.Errors}");
            }
        }
        else
        {
            throw new CustomException($"Email {request.Email} is already registered.");
        }
    }

    public async Task<bool> ConfirmEmailAsync(string userId, string code)
    {
        var user = await _userManager.FindByIdAsync(userId);
        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);


        if(!result.Succeeded)
            throw new CustomException($"An error occured while confirming {user.Email}.");

        return result.Succeeded;
    }

    public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
    {
        var account = await _userManager.FindByEmailAsync(model.Email);

        // always return ok response to prevent email enumeration
        if (account == null) return;

        var code = await _userManager.GeneratePasswordResetTokenAsync(account);
        var route = "account/ResetPassword/";
        var _enpointUri = new Uri(string.Concat($"{origin}/", route));
        var emailRequest = new MailRequest()
        {
            Body = $"You reset token is - {code}\n Reset Password Link From <a href={_enpointUri}>here</a>",
            To = model.Email,
            Subject = "Reset Password",
        };
        await _mailService.SendAsync(emailRequest);
    }

    public async Task<string> ResetPassword(ResetPasswordRequest model)
    {
        var account = await _userManager.FindByEmailAsync(model.Email);
        if (account == null) throw new CustomException($"No Accounts Registered with {model.Email}.");
        var result = await _userManager.ResetPasswordAsync(account, model.Token, model.Password);
        if (result.Succeeded)
        {
            return "Password Resetted.";
        }
        else
        {
            throw new CustomException($"Error occured while reseting the password.");
        }
    }

    private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
    {
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var route = "account/confirmemail/";
        var _enpointUri = new Uri(string.Concat($"{origin}/", route));
        var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
        verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
        //Email Service Call Here
        return verificationUri;
    }

    public async Task<UserDto?> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        UserDto? dto = null;
        if (user != null)
        {
            dto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Image = user.Image,
                RoleType = user.RoleType,
            };
        }
        return dto;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
