using CohorteApi.Core.Interfaces;
using CohorteApi.Core.Models.Newsletter;
using CohorteApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CohorteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterBusiness _newsletterBusiness;
        public NewsletterController(INewsletterBusiness nlBusiness)
        {
            _newsletterBusiness = nlBusiness;
        }

        // GET: api/<Newsletter>
        [HttpGet]
        public IEnumerable<NewsletterDTO> Get()
        {
           return  _newsletterBusiness.GetAll();
        }

        //// GET api/<Newsletter>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<Newsletter>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<Newsletter>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Newsletter>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        }


        //POST api/
        [HttpPost("subscribe")]
        public Subscription Subscribe(SubscribeDTO dto)
        {
            //if subscribed, send email confirming
            //TODO : Send Email
           return _newsletterBusiness.Subscribe(dto.Email);
        }

        //POST api/
        [HttpPost("unsubscribe")]
        public async Task< bool> Unsubscribe(SubscribeDTO dto)
        {
            var result = await  _newsletterBusiness.Unsubscribe(dto.Email);
            return result;
        }


        //POST api/newseletter/subscriptions
        [HttpGet()]
        [Route("subscriptions")]
        public IEnumerable<Subscription> GetSubscriptions()
        {
           return  _newsletterBusiness.GetAllSubscriptions();
        }

    }
}
