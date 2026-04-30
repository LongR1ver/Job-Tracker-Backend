using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<ApplicationGroup> ApplicationGroups { get; set; } = new List<ApplicationGroup>();
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
