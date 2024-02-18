using JobFinder.Application.Interfaces.Shared;
using JobFinder.Application.Models.ServiceModel;
using JobFinder.Application.Models.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace JobFinder.Infrastructure.Shared;
public class SMTPMailService : IMailService
{
    public MailSettings _mailSettings { get; }
    public ILogger<SMTPMailService> _logger { get; }

    public SMTPMailService(IOptions<MailSettings> mailSettings, ILogger<SMTPMailService> logger)
    {
        _mailSettings = mailSettings.Value;
        _logger = logger;
    }

    public async Task SendAsync(MailRequest request)
    {
        try
        {
            var email = new MimeMessage();

            // From
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, request.From ?? _mailSettings.From));

            // To
            email.To.Add(MailboxAddress.Parse(request.To));

            // Content
            var builder = new BodyBuilder();
            email.Sender = new MailboxAddress(request.DisplayName ?? _mailSettings.DisplayName, request.From ?? _mailSettings.From);
            email.Subject = request.Subject;
            builder.HtmlBody = request.Body;
         
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
    }
}