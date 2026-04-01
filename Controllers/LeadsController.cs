using ExchangeLeadSystem.DTOs.Lead;
using ExchangeLeadSystem.DTOs.Note;
using ExchangeLeadSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeLeadSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadsController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LeadResponseDto>> Create([FromBody] CreateLeadDto dto)
        {
            var lead = await _leadService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LeadResponseDto>>> GetAll()
        {
            var leads = await _leadService.GetAllAsync();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<LeadResponseDto>> GetById(int id)
        {
            var lead = await _leadService.GetByIdAsync(id);
            return Ok(lead);
        }

        [HttpPatch("{id}/status")]
        [Authorize]
        public async Task<ActionResult<LeadResponseDto>> UpdateStatus(int id, [FromBody] UpdateLeadStatusDto dto)
        {
            var lead = await _leadService.UpdateStatusAsync(id, dto);
            return Ok(lead);
        }

        [HttpPost("{id}/notes")]
        [Authorize]
        public async Task<ActionResult<LeadResponseDto>> AddNote(int id, [FromBody] CreateNoteDto dto)
        {
            var lead = await _leadService.AddNoteAsync(id, dto);
            return Ok(lead);
        }
    }
}