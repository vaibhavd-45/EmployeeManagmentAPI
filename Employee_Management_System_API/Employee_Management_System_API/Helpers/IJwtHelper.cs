using Employee_Management_System_API.Models;

namespace Employee_Management_System_API.Helpers
{
    public interface IJwtHelper
    {
        string GenerateToken(User user);
    }
}
