using Job_Application_Web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.Models
{
    public class ApplicationStatusHistory
    {
        public Guid Id { get; set; }

        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; } = null!;

        public ApplicationStatus OldStatus { get; set; }
        public ApplicationStatus NewStatus { get; set; }

        public string? Note { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }
}
