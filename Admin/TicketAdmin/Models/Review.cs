namespace TicketFanAdmin.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public bool IsShowed { get; set; } = true;
        public bool IsBanned { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

    }
}
