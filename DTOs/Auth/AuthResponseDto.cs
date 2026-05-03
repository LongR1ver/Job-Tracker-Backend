using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.Auth
{
    public class AuthResponseDto
    {
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;

        public string AccessToken { get; set; } = null!;
        public DateTime AccessTokenExpiresAt { get; set; }

        public string RefreshToken { get; set; } = null!;
        public DateTime RefreshTokenExpiresAt { get; set; }
    }
}
