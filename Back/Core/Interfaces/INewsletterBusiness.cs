using CohorteApi.Core.Models.Newsletter;
using CohorteApi.Models;

namespace CohorteApi.Core.Interfaces
{
    public interface INewsletterBusiness
    {
        IEnumerable<NewsletterDTO> GetAll();

        Subscription Subscribe(string email);

        Task<bool> Unsubscribe(string email);

        IEnumerable<Subscription> GetAllSubscriptions();
        Subscription GetSubscriptionByEmail(string email);
    }
}
