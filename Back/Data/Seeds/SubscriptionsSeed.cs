using CohorteApi.Models;

namespace CohorteApi.Data.Seeds
{
    public static class SubscriptionsSeed
    {
        public static IEnumerable<Subscription> GetData()
        {
            var subscriptions = new Subscription[] {
                //new Subscription() {Id =1 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test@domain.com"},
                //new Subscription()  {Id =2 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test2@domain.com"},
            };
            return subscriptions;
        }
    }
}
