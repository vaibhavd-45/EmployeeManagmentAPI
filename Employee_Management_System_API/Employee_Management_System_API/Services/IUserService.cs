using System.Threading.Tasks;
using Employee_Management_System_API.Models;
using Employee_Management_System_API.DTOs;

namespace Employee_Management_System_API.Services
{
    public interface IUserService
    {
        Task<User?> Authenticate(string username, string password);
        Task<bool> RegisterHR(string username, string password, string role, Guid adminId);
    }

}
