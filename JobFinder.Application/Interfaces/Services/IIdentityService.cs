using JobFinder.Application.Models.ServiceModel;
namespace JobFinder.Application.Interfaces.Services;

public interface IIdentityService
{
    Task<UserDto?> GetUserByIdAsync(string id);
    Task<UserDto> LoginAsync(LoginRequest request);
    Task LogoutAsync();
    Task<string> RegisterAsync(RegisterRequest request, string origin);
    Task ForgotPassword(ForgotPasswordRequest model, string origin);
    Task<string> ResetPassword(ResetPasswordRequest model);
    Task<bool> ConfirmEmailAsync(string userId, string code);
}
