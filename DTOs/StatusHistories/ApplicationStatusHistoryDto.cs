using Job_Application_Web.Models.Enums;

namespace Job_Application_Web.DTOs.StatusHistories
{
    public class ApplicationStatusHistoryDto
    {
        public Guid Id { get; set; }

        public Guid JobApplicationId { get; set; }

        public ApplicationStatus OldStatus { get; set; }
        public ApplicationStatus NewStatus { get; set; }

        public string? Note { get; set; }

        public DateTime ChangedAt { get; set; }
    }
}
