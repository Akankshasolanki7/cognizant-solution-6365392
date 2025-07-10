using Microsoft.AspNetCore.Mvc;
using CrudOperationsApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CrudOperationsApi.Controllers
{
    /// <summary>
    /// Employee Controller for comprehensive CRUD operations
    /// Demonstrates data create, update, delete operations with validation
    /// Uses FromBody attribute and hardcoded data as per requirements
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded data for demonstration as per requirements
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@company.com",
                Department = "IT",
                Salary = 75000,
                JoinDate = new DateTime(2023, 1, 15),
                IsActive = true
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@company.com",
                Department = "HR",
                Salary = 65000,
                JoinDate = new DateTime(2023, 3, 20),
                IsActive = true
            },
            new Employee
            {
                Id = 3,
                Name = "Bob Johnson",
                Email = "bob.johnson@company.com",
                Department = "Finance",
                Salary = 70000,
                JoinDate = new DateTime(2023, 2, 10),
                IsActive = true
            },
            new Employee
            {
                Id = 4,
                Name = "Alice Brown",
                Email = "alice.brown@company.com",
                Department = "Marketing",
                Salary = 60000,
                JoinDate = new DateTime(2023, 4, 5),
                IsActive = false
            }
        };

        /// <summary>
        /// GET: api/employee
        /// Returns all employees
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return Ok(employees);
        }

        /// <summary>
        /// GET: api/employee/{id}
        /// Returns specific employee by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            // Check if ID is valid as per requirements
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return BadRequest("Invalid employee id"); // Same message as per requirements

            return Ok(employee);
        }

        /// <summary>
        /// POST: api/employee
        /// Creates new employee using FromBody attribute
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            // Validate model state
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(string.Join("; ", errors));
            }

            // Check if email already exists
            if (employees.Any(e => e.Email.Equals(employee.Email, StringComparison.OrdinalIgnoreCase)))
                return BadRequest("Employee with this email already exists");

            // Generate new ID
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;

            employees.Add(employee);
            return Ok(employee);
        }

        /// <summary>
        /// PUT: api/employee/{id}
        /// Updates existing employee data as per requirements
        /// Employee information updated based on user input using FromBody attribute
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // Check if ID value is lesser than or equal to 0 as per requirements
            if (id <= 0)
                return BadRequest("Invalid employee id");

            // Check if the value is greater than 0 but not available in the list
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
                return BadRequest("Invalid employee id"); // Same message as per requirements

            if (employee == null)
                return BadRequest("Employee data is required");

            // Validate model state
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(string.Join("; ", errors));
            }

            // Check if email already exists for another employee
            if (employees.Any(e => e.Id != id && e.Email.Equals(employee.Email, StringComparison.OrdinalIgnoreCase)))
                return BadRequest("Employee with this email already exists");

            // Use JSON data from input body to update the hardcoded list as per requirements
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.JoinDate = employee.JoinDate;
            existingEmployee.IsActive = employee.IsActive;

            // Filter the employee list data for the input id and return as output
            return Ok(existingEmployee);
        }

        /// <summary>
        /// DELETE: api/employee/{id}
        /// Deletes employee by ID
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteEmployee(int id)
        {
            // Check if ID is valid
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return BadRequest("Invalid employee id");

            employees.Remove(employee);
            return Ok($"Employee {employee.Name} deleted successfully");
        }

        /// <summary>
        /// GET: api/employee/active
        /// Returns only active employees
        /// </summary>
        [HttpGet("active")]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetActiveEmployees()
        {
            var activeEmployees = employees.Where(e => e.IsActive).ToList();
            return Ok(activeEmployees);
        }

        /// <summary>
        /// GET: api/employee/department/{department}
        /// Returns employees by department
        /// </summary>
        [HttpGet("department/{department}")]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetEmployeesByDepartment(string department)
        {
            if (string.IsNullOrEmpty(department))
                return BadRequest("Department name is required");

            var deptEmployees = employees
                .Where(e => e.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!deptEmployees.Any())
                return NotFound($"No employees found in {department} department");

            return Ok(deptEmployees);
        }

        /// <summary>
        /// PATCH: api/employee/{id}/status
        /// Updates employee status (active/inactive)
        /// </summary>
        [HttpPatch("{id}/status")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Employee> UpdateEmployeeStatus(int id, [FromBody] bool isActive)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return BadRequest("Invalid employee id");

            employee.IsActive = isActive;
            return Ok(employee);
        }
    }
}
