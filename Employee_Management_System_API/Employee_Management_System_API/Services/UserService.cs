using Employee_Management_System_API.Repositories;
using Employee_Management_System_API.Models;

namespace Employee_Management_System_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        // ✅ Admin can register HR users
        public async Task<bool> RegisterHR(string username, string password, string role, Guid adminId)
        {
            var admin = await _userRepository.GetUserById(adminId);
            if (admin == null || admin.Role != "Admin")
            {
                return false; // ❌ Not an admin, return false
            }

            var newHR = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = "HR" // HR Role
            };

            return await _userRepository.AddUser(newHR);
        }
    }
}
