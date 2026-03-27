using ExchangeLeadSystem.Domain.Entities;
using ExchangeLeadSystem.DTOs.Lead;
using ExchangeLeadSystem.DTOs.Note;
using ExchangeLeadSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExchangeLeadSystem.Services
{
    public class LeadService : ILeadService
    {
        private readonly AppDbContext _context;

        public LeadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LeadResponseDto> CreateAsync(CreateLeadDto dto)
        {
            var lead = new Lead
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                ClientType = dto.ClientType,
                OperationType = dto.OperationType,
                Currency = dto.Currency,
                Message = dto.Message
            };

            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            return MapToResponseDto(lead);
        }

        public async Task<IEnumerable<LeadResponseDto>> GetAllAsync()
        {
            var leads = await _context.Leads
                .Include(l => l.Notes)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();

            return leads.Select(MapToResponseDto);
        }

        public async Task<LeadResponseDto?> GetByIdAsync(int id)
        {
            var lead = await _context.Leads
                .Include(l => l.Notes)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lead == null) return null;

            return MapToResponseDto(lead);
        }

        public async Task<LeadResponseDto> UpdateStatusAsync(int id, UpdateLeadStatusDto dto)
        {
            var lead = await _context.Leads.FindAsync(id)
                ?? throw new KeyNotFoundException($"Lead {id} not found");

            lead.Status = dto.Status;
            await _context.SaveChangesAsync();

            return MapToResponseDto(lead);
        }

        public async Task<LeadResponseDto> AddNoteAsync(int id, CreateNoteDto dto)
        {
            var lead = await _context.Leads
                .Include(l => l.Notes)
                .FirstOrDefaultAsync(l => l.Id == id)
                ?? throw new KeyNotFoundException($"Lead {id} not found");

            var note = new LeadNote
            {
                LeadId = id,
                Content = dto.Content
            };

            lead.Notes.Add(note);
            await _context.SaveChangesAsync();

            return MapToResponseDto(lead);
        }

        private static LeadResponseDto MapToResponseDto(Lead lead)
        {
            return new LeadResponseDto
            {
                Id = lead.Id,
                Name = lead.Name,
                Phone = lead.Phone,
                Email = lead.Email,
                ClientType = lead.ClientType,
                OperationType = lead.OperationType,
                Currency = lead.Currency,
                Message = lead.Message,
                Status = lead.Status,
                CreatedAt = lead.CreatedAt,
                Notes = lead.Notes.Select(n => new NoteResponseDto
                {
                    Id = n.Id,
                    Content = n.Content,
                    CreatedAt = n.CreatedAt
                }).ToList()
            };
        }
    }
}