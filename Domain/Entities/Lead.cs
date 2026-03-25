using ExchangeLeadSystem.Domain.Enums;

namespace ExchangeLeadSystem.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public ClientType ClientType { get; set; }
        public OperationType OperationType { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string? Message { get; set; }
        public LeadStatus Status { get; set; } = LeadStatus.New;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<LeadNote> Notes { get; set; } = new List<LeadNote>();
    }
}