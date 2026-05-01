using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.ApplicationGroups
{
    public class ApplicationGroupDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public string? Color { get; set; }
        public int JobApplicationCount { get; set; }
    }
}
