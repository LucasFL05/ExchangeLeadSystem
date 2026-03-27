using ExchangeLeadSystem.DTOs.Auth;
using ExchangeLeadSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeLeadSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
                return Unauthorized(new { message = "Email ou senha inválidos" });

            return Ok(result);
        }
    }
}