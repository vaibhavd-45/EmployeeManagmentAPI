using Employee_Management_System_API.Models;

namespace Employee_Management_System_API.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUserById(Guid id);
        Task<bool> AddUser(User user); // Ensure this returns Task<bool>
    }
}
