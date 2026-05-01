using Job_Application_Web.Models.Enums;

namespace Job_Application_Web.DTOs.JobApplications
{
    public class UpdateJobApplicationDto
    {
        public Guid? ApplicationGroupId { get; set; }

        public DateTime? AppliedDateTime { get; set; }

        public string? Url { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }

        public EmploymentType? EmploymentType { get; set; }
        public WorkMode? WorkMode { get; set; }
        public ApplicationStatus? Status { get; set; }
    }
}
