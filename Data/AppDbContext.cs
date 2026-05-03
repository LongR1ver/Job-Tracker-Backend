using Job_Application_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_Application_Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<ApplicationGroup> ApplicationGroups => Set<ApplicationGroup>();
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
        public DbSet<ApplicationStatusHistory> ApplicationStatusHistories => Set<ApplicationStatusHistory>();
        public DbSet<Reminder> Reminders => Set<Reminder>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            // RefreshToken
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ApplicationGroup
            modelBuilder.Entity<ApplicationGroup>()
                .HasOne(g => g.User)
                .WithMany(u => u.ApplicationGroups)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationGroup>()
                .Property(g => g.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<ApplicationGroup>()
                .Property(g => g.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<ApplicationGroup>()
                .Property(g => g.Color)
                .HasMaxLength(50);

            // JobApplication
            modelBuilder.Entity<JobApplication>()
                .HasOne(j => j.User)
                .WithMany(u => u.JobApplications)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobApplication>()
                .HasOne(j => j.ApplicationGroup)
                .WithMany(g => g.JobApplications)
                .HasForeignKey(j => j.ApplicationGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.Url)
                .HasMaxLength(1000)
                .IsRequired();

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.CompanyName)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.JobTitle)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.Location)
                .HasMaxLength(200);

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.Notes)
                .HasMaxLength(2000);

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.EmploymentType)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.WorkMode)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<JobApplication>()
                .Property(j => j.Status)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<JobApplication>()
                .HasIndex(j => j.UserId);

            modelBuilder.Entity<JobApplication>()
                .HasIndex(j => j.ApplicationGroupId);

            modelBuilder.Entity<JobApplication>()
                .HasIndex(j => j.Status);

            // ApplicationStatusHistory
            modelBuilder.Entity<ApplicationStatusHistory>()
                .HasOne(h => h.JobApplication)
                .WithMany(j => j.ApplicationStatusHistories)
                .HasForeignKey(h => h.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationStatusHistory>()
                .Property(h => h.OldStatus)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<ApplicationStatusHistory>()
                .Property(h => h.NewStatus)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<ApplicationStatusHistory>()
                .Property(h => h.Note)
                .HasMaxLength(1000);

            // Reminder
            modelBuilder.Entity<Reminder>()
                .HasOne(r => r.JobApplication)
                .WithMany(j => j.Reminders)
                .HasForeignKey(r => r.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reminder>()
                .Property(r => r.Message)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Reminder>()
                .HasIndex(r => r.ReminderDateTime);

            modelBuilder.Entity<Reminder>()
                .HasIndex(r => r.IsCompleted);
        }
    }
}
