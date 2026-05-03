using Job_Application_Web.DTOs.Auth;
using Job_Application_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Application_Web.Controllers
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

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result == null)
            {
                return BadRequest(new
                {
                    message = "Email is already registered."
                });
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AuthResponseDto>> RefreshToken(RefreshTokenRequestDto dto)
        {
            var result = await _authService.RefreshTokenAsync(dto);

            if (result == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid or expired refresh token."
                });
            }

            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutRequestDto dto)
        {
            var result = await _authService.LogoutAsync(dto);

            if (!result)
            {
                return BadRequest(new
                {
                    message = "Invalid refresh token."
                });
            }

            return NoContent();
        }
    }
}
