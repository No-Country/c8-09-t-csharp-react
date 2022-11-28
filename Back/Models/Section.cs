using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public decimal  Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
        public List<Row>? Rows { get; set; }
        public List<Restriction>? Restrictions { get; set; }
    }
}
