using System;
using System.Collections.Generic;
using System.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace KnightsBridge.Services
{
    [AllowAnonymous]
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public string apiKey = Environment.GetEnvironmentVariable("KNIGHTSBRIDGE_ENVIRONMENT_SENDGRID_KEY");


        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(apiKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("Jason.saar@gmail.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }
    }
}