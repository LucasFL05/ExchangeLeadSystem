using ExchangeLeadSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExchangeLeadSystem.DTOs.Lead
{
    public class CreateLeadDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [MaxLength(20, ErrorMessage = "Telefone deve ter no máximo 20 caracteres")]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Email inválido")]
        [MaxLength(100, ErrorMessage = "Email deve ter no máximo 100 caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Tipo de cliente é obrigatório")]
        public ClientType ClientType { get; set; }

        [Required(ErrorMessage = "Tipo de operação é obrigatório")]
        public OperationType OperationType { get; set; }

        [Required(ErrorMessage = "Moeda é obrigatória")]
        [MaxLength(10, ErrorMessage = "Moeda deve ter no máximo 10 caracteres")]
        public string Currency { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Mensagem deve ter no máximo 500 caracteres")]
        public string? Message { get; set; }
    }
}