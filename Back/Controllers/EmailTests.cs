using CohorteApi.Core.Business.Email;
using CohorteApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CohorteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTests : ControllerBase
    {
        IEmailBusiness _emailBS;
        public EmailTests(IEmailBusiness emailBS)
        {
            _emailBS = emailBS;
        }


        /// <summary>
        /// Test Email with default content
        /// </summary>
        /// <remarks>
        /// You can send your own email content to check either functionality or template design.
        /// Bear in mind that images need to be hosted or embeded as base64. 
        /// https://www.mailinator.com/v4/public/inboxes.jsp?to=tiketfan-TestEmailContent
        /// 
        /// In current depelopmente templates will come in a zip folder with its own images
        /// </remarks>
        /// <param name="recipient">The email</param>
     
        [HttpPost]
        public async Task<bool> SendEmail(string recipient = "tiketfan-TestEmailContent@mailinator.com", [FromBody] string content = "<h1>Test Content</h1>")
        {
            var body = content;
            if (body == "")
                body = System.IO.File.ReadAllText("core/business/email/templates/template1.html");

            var recipients = new[] { recipient };
            var message = new Message(recipients, "Email Test", body);
            await _emailBS.SendEmailAsync(message);
            return true;
        }



        /// <summary>
        /// Test Email result when Registering a new User
        /// </summary>
        /// <remarks>
        ///  You can check the email by sending it to your email or to the the default test server on mailinator.com
        /// <see href="https://www.mailinator.com/v4/public/inboxes.jsp?to=tiketfan-NewUser">HERE</see>
        /// https://www.mailinator.com/v4/public/inboxes.jsp?to=tiketfan-NewUser
        /// </remarks>
        /// <param name="recipient">The email recipient, by default will be tiketfan-NewUser@mailinator.com</param>
        /// <param name="userName">The username used in the template, by default will be newUser</param>
        /// <response code="200">Email was sent successsfully</response>
        /// <response code="400"></response>
        [HttpGet]
        [Route("Welcome")]
        public async Task SendWelcomeEmail(string userName = "newUser", string recipient = "tiketfan-NewUser@mailinator.com")
        {
            await _emailBS.SendWelcomeEmailAsync(userName, recipient);
        }
    }
}
