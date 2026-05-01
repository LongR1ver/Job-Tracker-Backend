using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.DTOs.Reminders
{
    public class UpdateReminderDto
    {
        public DateTime ReminderDateTime { get; set; }

        [Required]
        public string Message { get; set; } = null!;

        public bool IsCompleted { get; set; }
    }
}
