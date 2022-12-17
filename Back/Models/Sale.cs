using Microsoft.AspNetCore.Identity;

namespace CohorteApi.Models
{
    public class Sale
    {
        public int Id { get; set; }   
        public AppUser User { get; set; }     
        public Event Event { get; set; }
        public int EventId { get; set; }
        public int Qty { get; set; }
        public string Section { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.Now.ToUniversalTime();
    }
}
