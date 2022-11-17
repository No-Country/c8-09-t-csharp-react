using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Email]
        [Required]
        public string Email { get; set; }
        public DateTime DateSubscribed { get; set ; }
        public bool IsActive { get; set; } = true;
    }
}
