using CohorteApi.Core.Interfaces;
using CohorteApi.Data;
using CohorteApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GenerateTestUsers([FromServices] ApplicationDbContext context, [FromServices] UserManager<AppUser> umanager)
        {
            var password = "Tiketfan123!";
            var user = RandomString(6);
            var admin = RandomString(6);
            //  umanager.CreateAsync()
            var u1 = new AppUser { UserName = user, Email = $"{user}@mailinator.com" };
            var u2 = new AppUser { UserName = admin, Email = $"{admin}@mailinator.com" };
            var r1 = await umanager.CreateAsync(u1, password);
            var r2 = await umanager.CreateAsync(u2, password);


            var a1 = await umanager.AddToRoleAsync(u1, "user");
            var a2 = await umanager.AddToRoleAsync(u2, "admin");

            var result = new[]
            {
                new {Username = user, Password = password, email =$"{user}@mailinator.com",  rol = "User", Succeeded = r1.Succeeded},
                new {Username = admin, Password = password, email =$"{admin}@mailinator.com", rol = "Admin", Succeeded = r2.Succeeded},
             };

            return new JsonResult(result);

            string RandomString(int length)
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }

        [HttpGet("GetUsersTesting")]
        public async Task<IActionResult> GetUsersTesting([FromServices] ApplicationDbContext context, [FromServices] UserManager<AppUser> umanager)
        {
            var result = await umanager.Users.Include(a => a.Sales).ThenInclude(a=>a.Event).ThenInclude(a=>a.Category).Include(a => a.Reviews).ToListAsync();
            return new JsonResult(result);
        }

        [HttpGet("GenerateSales")]
        public async Task<IActionResult> GenerateSale([FromServices] ApplicationDbContext context, [FromServices] UserManager<AppUser> umanager)
        {            
            var user = await umanager.FindByEmailAsync("manuel@mailinator.com");
            var _event = await context.Events.FirstAsync();
            Sale sale = new() 
            {
                CreatedAt= DateTime.Now,
                Event= _event,
                Price = (decimal)49.99,
                Qty=1,
                User = user,
                Section = "Platea"
            };
            context.Add(sale);           
            return new JsonResult(await context.SaveChangesAsync());
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
                    CategoryId = new Random().Next(1,6),
                    FrontPageImage = "https://cohorteapi.azurewebsites.net/images/Event_1_FrontPage.jpg",
                    Thumbnail = "https://cohorteapi.azurewebsites.net/images/Event_1_Thumbnail.jpg",
                    EventName = "BIENVENIDO DICIEMBRE - UNA ALBORADA POR TODO LO ALTO",
                    EventDescription="Ven con nosotros a vivir una magnífica noche ubicada en la mejor zona de Medellín, con un acceso visual 360 de toda la ciudad, acompáñanos en esta noche mágica a vivir una alborada por todo lo alto, con una exquisita marranada gourmet.",
                    Sections = new List<Section>
                    {
                        new Section()
                        {
                            Price = 1,
                            Name = "Platea",
                            AvailableSeats = 50,
                            TotalSeats = 50
                        },

                        new Section()
                        {
                            Price = 1,
                            Name = "Vip",
                            AvailableSeats = 200,
                            TotalSeats = 200
                        },
                    },
                    Venue  = "Estadio Garcia",
                    Created = DateTime.Parse("2022-11-01T13:42:42.55"),
                    EventTime = DateTime.Parse("2022-11-30T13:42:42.55"),
                    },
                    new Event() {

                        CategoryId = new Random().Next(1,6),
                     FrontPageImage = "https://cohorteapi.azurewebsites.net/images/Event_2_FrontPage.jpg",
                     Thumbnail  =   "https://cohorteapi.azurewebsites.net/images/Event_2_Thumbnail.jpg",
                    EventName = "KEVIN JOHANSEN - TU VE TOUR",
                    EventDescription="two nights with two different sets and two different opening acts",
                    Venue  = "Teatro Jorge Eliécer Gaitán",
                    Sections = new List<Section>
                    {
                        new Section()
                        {
                            Price = 1,
                            Name = "Platea",
                            AvailableSeats = 100,
                            TotalSeats = 100
                        },

                        new Section()
                        {
                            Price = 1,
                            Name = "Diamante",
                            AvailableSeats = 180,
                            TotalSeats = 180
                        },
                    },
                    Created = DateTime.Parse("2022-11-24T13:42:42.55"),
                    EventTime = DateTime.Parse("2022-12-03T13:42:42.55"),
                    },
                    new Event() {

                     CategoryId = new Random().Next(1,6),
                    FrontPageImage = "https://cohorteapi.azurewebsites.net/images/Event_3_FrontPage.jpg",
                    Thumbnail  =   "https://cohorteapi.azurewebsites.net/images/Event_3_Thumbnail.jpg",
                    EventName = "NATALIA JIMÉNEZ 20 AÑOS - ANTOLOGÍA TOUR - MEDELLÍN",
                    EventDescription="two nights with two different sets and two different opening acts",
                    Venue  = "Teatro de la Universidad de Medellín",
                    Sections = new List<Section>
                    {
                        new Section()
                        {
                            Price = 1,
                            Name = "Oro",
                            AvailableSeats = 15,
                            TotalSeats = 15
                        },

                        new Section()
                        {
                            Price = 1,
                            Name = "Platinum",
                            AvailableSeats = 100,
                            TotalSeats = 100
                        },
                    },
                    Created = DateTime.Parse("2022-11-24T13:42:42.55"),
                    EventTime = DateTime.Parse("2023-03-23T13:42:42.55"),
                    }};   
            context.Events.AddRange(objs);
            context.SaveChanges();
            return objs;
        }
        [HttpPost("DeleteEvents")]
        public IActionResult DeleteEvents([FromServices] ApplicationDbContext context)
        {
            context.RemoveRange(context.Events.Include(a => a.Sections).ToList());
            var count = context.SaveChanges();
            return Ok($"Deleted {count} rows");
        }

        [HttpPost("UploadFiles")]
        public IActionResult UploadImages([FromForm] List<IFormFile> files, string folder = "images")
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
        public async Task<bool> SendEmail(string recipient = "tiketfan-TestEmailContent@mailinator.com", string content = "<h1>Test Content</h1>")
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
