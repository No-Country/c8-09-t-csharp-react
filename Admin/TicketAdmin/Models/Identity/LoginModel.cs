using System.ComponentModel.DataAnnotations;

namespace TicketFanAdmin.Models.Identity
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; } = "user@mailinator.com";

        [Required]
        public string Password { get; set; } = "Tiketfan123!";

    }
}