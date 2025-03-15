using Employee_Management_System_API.Data;
using Employee_Management_System_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Management_System_API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving employees.", ex);
            }
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    throw new KeyNotFoundException($"Employee with ID {id} not found.");
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the employee with ID {id}.", ex);
            }
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the employee.", ex);
            }
        }

        public async Task<Employee?> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var existing = await _context.Employees.FindAsync(id);
                if (existing == null)
                {
                    throw new KeyNotFoundException($"Employee with ID {id} not found.");
                }

                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Email = employee.Email;
                existing.Position = employee.Position;
                existing.Salary = employee.Salary;

                await _context.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the employee with ID {id}.", ex);
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    throw new KeyNotFoundException($"Employee with ID {id} not found.");
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the employee with ID {id}.", ex);
            }
        }
    }
}
