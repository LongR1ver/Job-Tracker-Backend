using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.Users
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
