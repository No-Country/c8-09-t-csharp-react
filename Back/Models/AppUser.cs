using Microsoft.AspNetCore.Identity;

namespace CohorteApi.Models
{
    public class AppUser: IdentityUser
    {
        public ICollection<Sale> Sales { get; set; } =  new List<Sale>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
