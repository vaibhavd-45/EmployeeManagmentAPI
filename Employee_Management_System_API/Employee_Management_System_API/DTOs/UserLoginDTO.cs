using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System_API.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }

}
