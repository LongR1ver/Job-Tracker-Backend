using Job_Application_Web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.JobApplications
{
    public class CreateJobApplicationDto
    {
        public Guid? ApplicationGroupId { get; set; }

        public DateTime? AppliedDateTime { get; set; }

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
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Applied;
    }
}
