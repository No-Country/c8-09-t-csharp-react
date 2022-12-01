using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CohorteApi.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
      //  [ForeignKey("EventTag")]
      //  public int EventId { get; set; }
      ////  public Event Event { get; set; }
    }
}
