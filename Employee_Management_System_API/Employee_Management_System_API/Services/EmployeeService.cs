using Employee_Management_System_API.Models;
using Employee_Management_System_API.Repositories;

namespace Employee_Management_System_API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees() => await _repository.GetAllEmployees();
        public async Task<Employee?> GetEmployeeById(int id) => await _repository.GetEmployeeById(id);
        public async Task<Employee> AddEmployee(Employee employee) => await _repository.AddEmployee(employee);
        public async Task<Employee?> UpdateEmployee(int id, Employee employee) => await _repository.UpdateEmployee(id, employee);
        public async Task<bool> DeleteEmployee(int id) => await _repository.DeleteEmployee(id);
    }

}
