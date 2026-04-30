using Job_Application_Web.Models.Enums;

namespace Job_Application_Web.DTOs.JobApplications
{
    public class UpdateJobApplicationStatusDto
    {
        public ApplicationStatus NewStatus { get; set; }
        public string? Note { get; set; }
    }
}
