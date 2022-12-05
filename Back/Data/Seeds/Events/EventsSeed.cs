using System.Data;
using CohorteApi.Models;

namespace CohorteApi.Data.Seeds
{
    public static class EventsSeed
    {
        public static IEnumerable<Event> GetData()
        {
            //var objs = new[] {
            //    new Event() {Id=1,
            //         FrontPageImage = "http://loremflickr.com/640/480/nightlife",
            //        EventName = "Blink-182(Estadio Garcia)",
            //        EventDescription="Ven y disfrita de blink-182 en el estadio garcia",
            //        Price = 999.99,
            //        AvailableSeats = 500,
            //        Venue  = "stadio garcia",
            //        Created = DateTime.Parse("2022-11-24T13:42:42.55"),
            //        EventTime = DateTime.Parse("2022-11-28T13:42:42.55"),
            //        //EventTags = new[]{
            //        //    new Tag() { Id=1 } ,
            //        //    new Tag() { Id=2 } ,
            //        //    new Tag() { Id=3 } ,
            //        //}
            //        },
            //        new Event() {Id=2,
            //         FrontPageImage = "http://loremflickr.com/640/480/nightlife",
            //        EventName = "Paramore",
            //        EventDescription="Lorem Ipsum",
            //        Price = 799.99,
            //        Venue  = "stadio garcia",
            //        AvailableSeats = 250,
            //        Created = DateTime.Parse("2022-11-24T13:42:42.55"),
            //        EventTime = DateTime.Parse("2022-11-28T13:42:42.55"),
            //        //EventTags = new[]{
            //        //    new Tag() { Id=4 } ,
            //        //    new Tag() { Id=5 } ,
            //        //},
            //       // Sections = new[] { new Section() { Name = "VIP" } }

            //        }};


            var objs = new[] {
                new Event() {
                    Id=1,
                    CategoryId = 1,
                    FrontPageImage = "https://cohorteapi.azurewebsites.net/images/event1FrontPage.jpg",
                    Thumbnail = "https://cohorteapi.azurewebsites.net/images/event1-thumb.jpg",
                    EventName = "BIENVENIDO DICIEMBRE - UNA ALBORADA POR TODO LO ALTO",
                    EventDescription="Ven con nosotros a vivir una magnífica noche ubicada en la mejor zona de Medellín, con un acceso visual 360 de toda la ciudad, acompáñanos en esta noche mágica a vivir una alborada por todo lo alto, con una exquisita marranada gourmet.",
                    //Price = 10,
                    //AvailableSeats = 500,
                    Venue  = "stadio garcia",
                    Created = DateTime.Parse("2022-11-01T13:42:42.55"),
                    EventTime = DateTime.Parse("2022-11-30T13:42:42.55"),
                    },
                    new Event() {
                        Id=2,
                        CategoryId = 2,
                     FrontPageImage = "https://cohorteapi.azurewebsites.net/images/evento2-Front.jpg",
                     Thumbnail  =   "https://cohorteapi.azurewebsites.net/images/evento2-thumb.jpg",
                    EventName = "KEVIN JOHANSEN - TU VE TOUR",
                    EventDescription="",
                    //Price = 25,
                    Venue  = "Teatro Jorge Eliécer Gaitán",
                    //AvailableSeats = 250,
                    Created = DateTime.Parse("2022-11-24T13:42:42.55"),
                    EventTime = DateTime.Parse("2022-12-03T13:42:42.55"),
                    },
                    new Event() {
                        Id=3,
                        CategoryId = 3,
                    FrontPageImage = "https://cohorteapi.azurewebsites.net/images/evento3%20(1).jpg",
                    Thumbnail  =   "https://cohorteapi.azurewebsites.net/images/evento3%20(2).jpg",
                    EventName = "NATALIA JIMÉNEZ 20 AÑOS - ANTOLOGÍA TOUR - MEDELLÍN",
                    EventDescription="",
                    //Price = 30,
                    Venue  = "Teatro de la Universidad de Medellín",
                    //AvailableSeats = 250,
                    Created = DateTime.Parse("2022-11-24T13:42:42.55"),
                    EventTime = DateTime.Parse("2023-03-23T13:42:42.55"),
                    }};

            return objs;
        }
    }
}


