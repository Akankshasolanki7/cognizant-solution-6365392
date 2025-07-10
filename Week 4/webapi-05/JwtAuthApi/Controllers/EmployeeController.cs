using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JwtAuthApi.Models;

namespace JwtAuthApi.Controllers
{
    /// <summary>
    /// Employee Controller with Authorize attribute as per instructions
    /// Remove CustomAuthFilter and use Authorize attribute to check Authorization header with Bearer token
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "POC")] // Include role 'POC' in Authorize attribute as per instructions
    public class EmployeeController : ControllerBase
    {
        // Sample employee data
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Department = "IT", Salary = 75000, IsActive = true },
            new Employee { Id = 2, Name = "Jane Smith", Department = "HR", Salary = 65000, IsActive = true },
            new Employee { Id = 3, Name = "Bob Johnson", Department = "Finance", Salary = 70000, IsActive = true },
            new Employee { Id = 4, Name = "Alice Brown", Department = "Marketing", Salary = 60000, IsActive = false }
        };

        /// <summary>
        /// GET: api/employee
        /// Use Authorize attribute to check if request header contains 'Authorization' key with 'Bearer' token
        /// If token unavailable, 'Unauthorized' status message with code 401 will be thrown
        /// </summary>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        /// <summary>
        /// GET: api/employee/{id}
        /// Returns specific employee by ID
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");

            return Ok(employee);
        }
    }

    /// <summary>
    /// Employee2 Controller to test Admin,POC roles as per instructions
    /// Include role 'Admin' along with 'POC' in Authorize attribute
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")] // Include role 'Admin' along with 'POC' as per instructions
    public class Employee2Controller : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Department = "IT", Salary = 75000, IsActive = true },
            new Employee { Id = 2, Name = "Jane Smith", Department = "HR", Salary = 65000, IsActive = true }
        };

        /// <summary>
        /// GET: api/employee2
        /// Test with Admin,POC roles - should return OK with status code 200
        /// </summary>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }
    }
}
