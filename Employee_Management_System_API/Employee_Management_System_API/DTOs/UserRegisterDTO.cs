using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System_API.DTOs
{
    public class UserRegisterDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
