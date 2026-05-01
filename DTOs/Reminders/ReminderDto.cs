using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.Reminders
{
    public class ReminderDto
    {
        public Guid Id { get; set; }

        public Guid JobApplicationId { get; set; }

        public DateTime ReminderDateTime { get; set; }

        [Required]
        public string Message { get; set; } = null!;

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
