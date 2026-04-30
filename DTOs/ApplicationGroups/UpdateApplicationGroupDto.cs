using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.ApplicationGroups
{
    public class UpdateApplicationGroupDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Color { get; set; }
    }
}
