namespace CohorteApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public double Price { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime Created { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime EventTime { get; set; }
        public ICollection<Tag> EventTags { get; set; } = new List<Tag>();
    }
}
