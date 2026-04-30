using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.Models
{
    public class Reminder
    {
        public Guid Id { get; set; }

        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; } = null!;

        public DateTime ReminderDateTime { get; set; }
        [Required]
        public string Message { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
