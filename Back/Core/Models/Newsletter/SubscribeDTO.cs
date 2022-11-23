using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Core.Models.Newsletter
{
    public class SubscribeDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}