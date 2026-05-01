using Job_Application_Web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.JobApplications
{
    public class JobApplicationDto
    {
        public Guid Id { get; set; }

        public Guid? ApplicationGroupId { get; set; }
        public string? ApplicationGroupName { get; set; }

        public DateTime AppliedDateTime { get; set; }

        [Required]
        public string Url { get; set; } = null!;
        [Required]
        public string CompanyName { get; set; } = null!;
        [Required]
        public string JobTitle { get; set; } = null!;
        [Required]
        public string JobDescription { get; set; } = null!;

        public string? Location { get; set; }
        public string? Notes { get; set; }

        public EmploymentType EmploymentType { get; set; }
        public WorkMode WorkMode { get; set; }
        public ApplicationStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
