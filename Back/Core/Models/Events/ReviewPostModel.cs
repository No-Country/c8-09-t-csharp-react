using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Core.Models.Events
{
    public class ReviewPostModel
    {
       // [EmailAddress]
        //public string UserEmail { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}
