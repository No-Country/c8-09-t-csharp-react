using CohorteApi.Core.Interfaces;
using CohorteApi.Core.Models.Email;
using Org.BouncyCastle.Cms;
using System;

namespace CohorteApi.Core.Business.Email
{
    public class EmailBusiness : IEmailBusiness
    {
        readonly IEmailService _service;
        string templatesPath = "wwwroot/templates/auth/welcome";
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

        public Task SendRecoverPasswordEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async  Task SendWelcomeEmailAsync(string name,string email)
        {
            //TODO validations of emailadresss

            var welcomeTemplate = System.IO.File.ReadAllText($"{templatesPath}/welcome.html");
            var userName = name;
            var content = string.Format(welcomeTemplate, userName);

            var recipients = new[] { email };
            var message = new Message(recipients, "Welcome to TiketFan", content);
            await _service.SendEmailAsync(message);
        }
    }
}
