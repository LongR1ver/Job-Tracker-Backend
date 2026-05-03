using Job_Application_Web.DTOs.Auth;

namespace Job_Application_Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
        Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto dto);
        Task<bool> LogoutAsync(LogoutRequestDto dto);
    }
}
