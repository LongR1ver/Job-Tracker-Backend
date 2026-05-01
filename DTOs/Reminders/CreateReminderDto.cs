using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.Reminders
{
    public class CreateReminderDto
    {
        public Guid JobApplicationId { get; set; }

        public DateTime ReminderDateTime { get; set; }

        [Required]
        public string Message { get; set; } = null!;
    }
}
