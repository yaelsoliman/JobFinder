using JobFinder.Shared.Common;
using System.ComponentModel.DataAnnotations;
namespace JobFinder.Application.Models.ServiceModel;

public class RegisterRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public RoleType RoleType { get; set; }
}