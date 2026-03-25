namespace ExchangeLeadSystem.Domain.Entities
{
    public class LeadNote
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Lead Lead { get; set; } = null!;
    }
}