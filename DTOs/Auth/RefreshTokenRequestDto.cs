using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.Auth
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public string RefreshToken { get; set; } = null!;
    }
}
