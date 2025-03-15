using Employee_Management_System_API.Data;
using Employee_Management_System_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving user with username {username}.", ex);
            }
        }

        public async Task<User?> GetUserById(Guid id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    throw new KeyNotFoundException($"User with ID {id} not found.");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving user with ID {id}.", ex);
            }
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        public async Task<User> RegisterUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }
    }
}
