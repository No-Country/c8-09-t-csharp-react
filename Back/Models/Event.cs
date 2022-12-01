namespace CohorteApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }

        public string EventDescription { get; set; }
        public string FrontPageImage { get; set; }
        public string Thumbnail { get; set; }
        public string Venue { get; set; }

        public double Price { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime Created { get; init; } = DateTime.Now.ToUniversalTime();
        public DateTime EventTime { get; set; }
        public ICollection<Tag>? EventTags { get; set; } 

        //public ICollection<Section>? Sections { get; set; }

        
        public Event()
        {
            //for tests
            //this.Sections = new List<Section>();
            //this.Sections.Add(new Section() { Name = "VIP" });
            //this.Sections.Add(new Section() { Name =  "PLATINIUM" });
            //this.Sections.Add(new Section() { Name =  "GENERAL" });
            //this.Sections.Add(new Section() { Name =  "PALCO" });
        }
    }
}
