using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Core.Models.Newsletter
{
    public class SubscribeDTO
    {
        [Email]
        [Required]
        public string Email { get; set; }
    }
}