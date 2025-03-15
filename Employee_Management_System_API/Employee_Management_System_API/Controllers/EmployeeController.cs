using Employee_Management_System_API.Models;
using Employee_Management_System_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System_API.Controllers
{
    [Authorize(Roles = "Admin,HR")]
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service), "Employee service cannot be null.");
        }

        [Authorize(Roles = "Admin,HR")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _service.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving employees: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin,HR")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _service.GetEmployeeById(id);
                if (employee == null) return NotFound("Employee not found.");
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the employee: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin,HR")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Invalid employee data.");

            try
            {
                var createdEmployee = await _service.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the employee: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin,HR")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Invalid employee data.");

            try
            {
                var updatedEmployee = await _service.UpdateEmployee(id, employee);
                if (updatedEmployee == null) return NotFound("Employee not found.");
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the employee: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var deleted = await _service.DeleteEmployee(id);
                if (!deleted) return NotFound("Employee not found.");
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the employee: {ex.Message}");
            }
        }
    }
}
