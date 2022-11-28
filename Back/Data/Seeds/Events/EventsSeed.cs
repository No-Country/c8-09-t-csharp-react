using System.Data;
using CohorteApi.Models;

namespace CohorteApi.Data.Seeds
{
    public static class EventsSeed
    {
        public static IEnumerable<Event> GetData()
        {
            var objs = new[] {
                new Event() {Id=1,
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
                    new Event() {Id=2,
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

            return objs;
        }
    }
}


