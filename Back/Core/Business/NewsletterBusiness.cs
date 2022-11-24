using CohorteApi.Core.Interfaces;
using CohorteApi.Core.Models.Newsletter;
using CohorteApi.Data;
using CohorteApi.Models;

namespace CohorteApi.Core.Business
{
    public class NewsletterBusiness : INewsletterBusiness
    {
        ApplicationDbContext _context;

        public NewsletterBusiness(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<NewsletterDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _context.Subscriptions.ToList();
        }

        public Subscription GetSubscriptionByEmail(string email)
        {
            return _context.Subscriptions.FirstOrDefault(x => x.Email == email);
        }

        public Subscription Subscribe(string emailAddress)
        {
            var email = new System.Net.Mail.MailAddress(emailAddress).Address;
          

            //create
            var newSubscription = new Subscription()
            {
                Email = email,
                DateSubscribed = DateTime.Now,
            };

            var exists = GetSubscriptionByEmail(email);
            if (exists == null)
            {
                _context.Subscriptions.Add(newSubscription);
            }
            else
            {
                if (exists.IsActive) return exists;
                exists.IsActive = true;
                exists.DateSubscribed = DateTime.SpecifyKind(DateTime.Now,DateTimeKind.Utc);
            }

            try
            {
                var rows = _context.SaveChanges();
                return exists != null ? exists : newSubscription;
            }
            catch (Exception)
            {
                //log
                throw;
            }
        }

        public Task<bool> Unsubscribe(string email)
        {
            var exists = GetSubscriptionByEmail(email);
            if (exists == null) return Task.FromResult(true);

            exists.IsActive = false;

            try
            {
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
