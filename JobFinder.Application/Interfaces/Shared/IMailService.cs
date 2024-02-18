using JobFinder.Application.Models.ServiceModel;
namespace JobFinder.Application.Interfaces.Shared;

public interface IMailService
{
    Task SendAsync(MailRequest request);
}