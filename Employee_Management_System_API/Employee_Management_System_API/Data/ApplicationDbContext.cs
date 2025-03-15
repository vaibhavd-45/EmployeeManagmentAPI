using Employee_Management_System_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Employee_Management_System_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Database options cannot be null.");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("Database configuration is missing.");
            }

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            try
            {
                modelBuilder.Entity<User>().HasIndex(e => e.Username).IsUnique();
                modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
                modelBuilder.Entity<User>().Property(u => u.PasswordHash).HasMaxLength(400);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while configuring the database model.", ex);
            }
        }
    }
}
