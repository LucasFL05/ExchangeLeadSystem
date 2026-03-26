using ExchangeLeadSystem.DTOs.Note;
using ExchangeLeadSystem.Domain.Enums;

namespace ExchangeLeadSystem.DTOs.Lead
{
    public class LeadResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public ClientType ClientType { get; set; }
        public OperationType OperationType { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string? Message { get; set; }
        public LeadStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<NoteResponseDto> Notes { get; set; } = new List<NoteResponseDto>();
    }
}