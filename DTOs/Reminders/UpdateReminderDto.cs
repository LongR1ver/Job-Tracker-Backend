namespace Job_Application_Web.DTOs.Reminders
{
    public class UpdateReminderDto
    {
        public DateTime? ReminderDateTime { get; set; }

        public string? Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}
