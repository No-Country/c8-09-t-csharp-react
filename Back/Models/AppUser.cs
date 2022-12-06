using Microsoft.AspNetCore.Identity;

namespace CohorteApi.Models
{
    public class AppUser: IdentityUser
    {
        public ICollection<Sale> Sales { get; set; }
    }
}
