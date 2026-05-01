using Job_Application_Web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Job_Application_Web.Models
{
    public class JobApplication
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid? ApplicationGroupId { get; set; }
        public ApplicationGroup? ApplicationGroup { get; set; }

        public DateTime AppliedDateTime { get; set; } = DateTime.UtcNow;

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
        public ApplicationStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<ApplicationStatusHistory> ApplicationStatusHistories { get; set; } = new List<ApplicationStatusHistory>();
        public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
    }
}
