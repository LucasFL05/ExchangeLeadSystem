using ExchangeLeadSystem.Domain.Enums;

namespace ExchangeLeadSystem.DTOs.Lead
{
    public class CreateLeadDto
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public ClientType ClientType { get; set; }
        public OperationType OperationType { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string? Message { get; set; }
    }
}