using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        private string? Slug { get; set; }
        private List<Event> Events { get; set; }
    }
}
