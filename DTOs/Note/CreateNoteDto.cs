using System.ComponentModel.DataAnnotations;

namespace ExchangeLeadSystem.DTOs.Note
{
    public class CreateNoteDto
    {
        [Required(ErrorMessage = "Conteúdo é obrigatório")]
        [MaxLength(1000, ErrorMessage = "Nota deve ter no máximo 1000 caracteres")]
        public string Content { get; set; } = string.Empty;
    }
}