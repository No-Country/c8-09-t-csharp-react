using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public decimal  Price { get; set; }
        public string Name { get; set; }
        public int AvailableSeats { get; set; }
        public int TotalSeats { get; set; }
    }
}
