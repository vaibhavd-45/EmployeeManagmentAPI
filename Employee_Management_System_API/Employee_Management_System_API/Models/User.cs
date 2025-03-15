using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System_API.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } = "HR";

        public DateTime CreatedAt { get; set; }
    }
}
