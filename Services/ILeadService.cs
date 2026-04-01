using ExchangeLeadSystem.DTOs.Lead;
using ExchangeLeadSystem.DTOs.Note;

namespace ExchangeLeadSystem.Services
{
    public interface ILeadService
    {
        Task<LeadResponseDto> CreateAsync(CreateLeadDto dto);
        Task<IEnumerable<LeadResponseDto>> GetAllAsync();
        Task<LeadResponseDto> GetByIdAsync(int id);
        Task<LeadResponseDto> UpdateStatusAsync(int id, UpdateLeadStatusDto dto);
        Task<LeadResponseDto> AddNoteAsync(int id, CreateNoteDto dto);
    }
}