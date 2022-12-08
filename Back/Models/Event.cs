using System.ComponentModel.DataAnnotations.Schema;

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
        public string VenueImage { get; set; }
        public DateTime Created { get; init; } = DateTime.Now.ToUniversalTime();
        public DateTime EventTime { get; set; }    
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
