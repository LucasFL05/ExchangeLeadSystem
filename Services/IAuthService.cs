using ExchangeLeadSystem.DTOs.Auth;

namespace ExchangeLeadSystem.Services
{
    public interface IAuthService
    {
        Task<TokenResponseDto?> LoginAsync(LoginDto dto);
    }
}