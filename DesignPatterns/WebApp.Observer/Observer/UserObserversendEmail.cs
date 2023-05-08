using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApp.Observer.Models;

namespace WebApp.Observer.Observer
{
    public class UserObserversendEmail : IUserObserver
    {

        private readonly IServiceProvider _serviceProvider;

        public UserObserversendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public void CreateUser(AppUser user)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserversendEmail>>();


            var mailMessage = new MailMessage();
            var smptClient = new SmtpClient("host");

            mailMessage.From = new MailAddress("userName");
            mailMessage.To.Add(new MailAddress(user.Email));
            mailMessage.Subject = "Welcome to Our Website";
            mailMessage.Body = "In this mail,you can find out our website rules";

            mailMessage.IsBodyHtml = true;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential("userName", "password");
            smptClient.Send(mailMessage);
            logger.LogInformation($"Email was sent! UserMail= {user.Email}");
        }
    }
}
