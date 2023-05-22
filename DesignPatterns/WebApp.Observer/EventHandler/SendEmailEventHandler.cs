using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Observer.Events;

namespace WebApp.Observer.EventHandler
{
    public class SendEmailEventHandler : INotificationHandler<UserCreatedEvent>
    {

        private readonly ILogger<SendEmailEventHandler> _logger;

        public SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            var mailMessage = new MailMessage();
            var smptClient = new SmtpClient("host");

            mailMessage.From = new MailAddress("userName");
            mailMessage.To.Add(new MailAddress(notification.AppUser.Email));
            mailMessage.Subject = "Welcome to Our Website";
            mailMessage.Body = "In this mail,you can find out our website rules";

            mailMessage.IsBodyHtml = true;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential("userName", "password");
            smptClient.Send(mailMessage);
            _logger.LogInformation($"Email was sent! UserMail= {notification.AppUser.Email}");

            return Task.CompletedTask;
        }
    }
}
