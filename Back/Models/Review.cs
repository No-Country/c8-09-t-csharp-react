using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CohorteApi.Models
{
    public class Review
    {

        [Key]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }
        public bool IsShowed { get; set; } = true;
        public bool IsBanned { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

    }
}
