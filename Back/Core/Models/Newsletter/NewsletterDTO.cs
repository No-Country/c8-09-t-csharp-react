namespace CohorteApi.Core.Models.Newsletter
{
    public class NewsletterDTO
    {
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; } = true;
        public bool Sent { get; set; } = false;
        public DateTime? DateSent { get; set; } = null;
        public int Subscribers { get; set; }
        public string Campaign { get; set; }
    }
}
