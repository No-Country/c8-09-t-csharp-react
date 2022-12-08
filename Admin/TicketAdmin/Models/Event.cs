namespace TicketFanAdmin.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string FrontPageImage { get; set; }
        public string Thumbnail { get; set; }
        public string Venue { get; set; }
        public string VenueImage { get; set; }
        public DateTime Created { get; init; }
        public DateTime EventTime { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
