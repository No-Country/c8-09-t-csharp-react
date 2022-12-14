using CohorteApi.Core.Interfaces;
using CohorteApi.Core.Models.Email;
using CohorteApi.Models;
using Org.BouncyCastle.Cms;
using System;
using System.Xml.Linq;

namespace CohorteApi.Core.Business.Email
{
    public class EmailBusiness : IEmailBusiness
    {
        readonly IEmailService _service;
        string templatesPath = "wwwroot/templates/auth";
        public EmailBusiness( IEmailService service)
        {
            _service = service;
        }
        public Task SendContactEmailAsync(string to, string subject, string content)
        {
            //var message = new Message(to,subject,content)
            //_service.SendEmail()
            throw new NotImplementedException();
        }

        public async Task SendEmailAsync(Message emailModel)
        {
           await  _service.SendEmailAsync(emailModel);
        }

        public Task SendNewsLetterAsync(int id, List<string> emails)
        {
            throw new NotImplementedException();
        }

        public async Task SendRecoverPasswordEmailAsync(string email,string userName, string link,string title = "Recover your password")
        {
            var recoverypasswordTemplate = System.IO.File.ReadAllText($"{templatesPath}/ChangePassword.html");

            //get base url from settings
          
            var content = string.Format(recoverypasswordTemplate, new[] { userName, link });

            var recipients = new[] { email };
            var message = new Message(recipients, title, content);
            await _service.SendEmailAsync(message);
        }

        public async  Task SendWelcomeEmailAsync(string name,string email)
        {
            //TODO validations of emailadresss

            var welcomeTemplate = System.IO.File.ReadAllText($"{templatesPath}/welcome/welcome.html");
            var userName = name;
            var content = string.Format(welcomeTemplate, userName);

            var recipients = new[] { email };
            var message = new Message(recipients, "Welcome to TiketFan", content);
            await _service.SendEmailAsync(message);
        }

        public async Task SendNewsletterOptInEmail(string email)
        {
            var optInTemplate = System.IO.File.ReadAllText($"wwwroot/templates/optin.html");
            //  var email = name;
            optInTemplate= optInTemplate.Replace("#user#", "#");
            //var content = string.Format(optInTemplate, email);

            var recipients = new[] { email };
            var message = new Message(recipients, "Welcome to TiketFan Newsletter", optInTemplate);
            await _service.SendEmailAsync(message);
        }

        public async Task SendSaleConfirmationEmail(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task SendPaymentConfirmationEmail(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task SendCancelOrderConfirmationEmail(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
