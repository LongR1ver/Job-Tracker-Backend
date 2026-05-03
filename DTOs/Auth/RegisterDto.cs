using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = null!;

        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
    }
}
