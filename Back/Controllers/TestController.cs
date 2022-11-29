using CohorteApi.Core.Interfaces;
using CohorteApi.Data;
using CohorteApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Web;

namespace CohorteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestUsersController : ControllerBase
    {

        [HttpGet("GenerateRandomUsers")]
        public async Task<IActionResult> GenerateTestUsers([FromServices] ApplicationDbContext context, [FromServices] UserManager<IdentityUser> umanager)
        {
            var password = "Tikefan123!";
            var user = RandomString(6);
            var admin = RandomString(6);
            //  umanager.CreateAsync()
            var u1 = new IdentityUser { UserName = user, Email = $"{user}@mailinator.com" };
            var u2 = new IdentityUser { UserName = admin, Email = $"{admin}@mailinator.com" };
            var r1 = await umanager.CreateAsync(u1, password);
            var r2 =await umanager.CreateAsync(u2, password);


            var result = new[]
            {
                new {Username = user, Password = password, email =$"{user}@mailinator.com",  rol = "user", Succeeded = r1.Succeeded},
                new {Username = admin, Password = password, email =$"{user}@mailinator.com", rol = "admin", Succeeded = r1.Succeeded},
             };
            await umanager.AddToRoleAsync(u2, "admin");
            await umanager.AddToRoleAsync(u1, "user");

            return   new JsonResult(result);

            string RandomString(int length)
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TestGeneralesController : ControllerBase
    {
        [HttpGet("GenerateEvents")]
        public IEnumerable<Event> GenerateEvents([FromServices] ApplicationDbContext context)
        {
            var objs = new[] {
                new Event() {
                    //Id=1,
                     FrontPageImage = "http://loremflickr.com/640/480/nightlife",
                    EventName = "Blink-182(Estadio Garcia)",
                    EventDescription="Ven y disfrita de blink-182 en el estadio garcia",
                    Price = 999.99,
                    AvailableSeats = 500,
                    Venue  = "stadio garcia",
                    Created = DateTime.Parse("2022-11-24T13:42:42.55"),
                    EventTime = DateTime.Parse("2022-11-28T13:42:42.55"),
                    //EventTags = new[]{
                    //    new Tag() { Id=1 } ,
                    //    new Tag() { Id=2 } ,
                    //    new Tag() { Id=3 } ,
                    //}
                    },
                    new Event() {
                        //Id=2,
                     FrontPageImage = "http://loremflickr.com/640/480/nightlife",
                    EventName = "Paramore",
                    EventDescription="Lorem Ipsum",
                    Price = 799.99,
                    Venue  = "stadio garcia",
                    AvailableSeats = 250,
                    Created = DateTime.Parse("2022-11-24T13:42:42.55"),
                    EventTime = DateTime.Parse("2022-11-28T13:42:42.55"),
                    //EventTags = new[]{
                    //    new Tag() { Id=4 } ,
                    //    new Tag() { Id=5 } ,
                    //},
                   // Sections = new[] { new Section() { Name = "VIP" } }

                    }};

            context.Events.AddRange(objs);
            context.SaveChanges();
            return objs;
        }

        [HttpPost("UploadFiles")]
        public IActionResult UploadImages([FromForm] List<IFormFile> files,string folder ="images")
        {
            var path = $"wwwroot/{folder}";
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var url = this.HttpContext.Request.Scheme + "://" +
                    this.HttpContext.Request.Host + "/" +
                    path.Replace("wwwroot/", "");

            List<(string, string, bool)> results = new();

            foreach (var model in files)
            {
                // if file is exe,dll,bin etc  = >fail
                //string fileName = HttpUtility.UrlEncode(model.FileName);
                string fileName = model.FileName;
                string fileNameWithPath = Path.Combine(path, fileName);

                try
                {
                    using (var fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        model.OpenReadStream().CopyTo(fileStream);
                    }
                    var uri = new Uri(url + $"/{fileName}");

                    results.Add((fileName, uri.AbsoluteUri, true));
                }
                catch (Exception e)
                {
                    results.Add((fileName, e.Message, false));
                }
            }

            var json = results.Select(x => new { File = x.Item1, Url = x.Item2, Success = x.Item3 });
            return new JsonResult(json);
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class TestsEmailController : ControllerBase
    {
        IEmailBusiness _emailBS;
        public TestsEmailController(IEmailBusiness emailBS)
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
