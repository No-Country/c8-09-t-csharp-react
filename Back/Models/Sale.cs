using Microsoft.AspNetCore.Identity;

namespace CohorteApi.Models
{
    public class Sale
    {
        public int Id { get; set; }   
        public IdentityUser User { get; set; }
        public int UserId { get; set; }
        public Event Event { get; set; }
        public string Section { get; set; }
        public decimal Price { get; set; }
    }    
}
