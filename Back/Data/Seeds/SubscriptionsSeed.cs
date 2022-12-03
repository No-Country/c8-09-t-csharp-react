using CohorteApi.Models;

namespace CohorteApi.Data.Seeds
{
    public static class SubscriptionsSeed
    {
        public static IEnumerable<Subscription> GetData()
        {
            var subscriptions = new Subscription[] {
                new Subscription() {Id =1 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test@mailinator.com"},
                new Subscription()  {Id =2 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test2@mailinator.com"},
                new Subscription()  {Id =3 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test3@mailinator.com"},
                new Subscription()  {Id =4 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test4@mailinator.com"},
                new Subscription()  {Id =5 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test5@mailinator.com"},
                new Subscription()  {Id =6 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test6@mailinator.com"},
                new Subscription()  {Id =7 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test7@mailinator.com"},
                new Subscription()  {Id =8 , DateSubscribed = DateTime.SpecifyKind(new DateTime(2022,8,1),DateTimeKind.Utc),Email = "test8@mailinator.com"},
            };
            return subscriptions;
        }
    }
}
