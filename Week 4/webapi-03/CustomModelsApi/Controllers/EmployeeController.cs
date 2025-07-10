using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CustomModelsApi.Models;
using CustomModelsApi.Filters;

namespace CustomModelsApi.Controllers
{
    /// <summary>
    /// Employee Controller with custom model class and filters
    /// Demonstrates complex object handling, custom filters, and exception management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter] // Apply custom authorization filter to all actions
    [ServiceFilter(typeof(CustomExceptionFilter))] // Apply custom exception filter
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees;

        // Constructor: Create few records as per requirements
        public EmployeeController()
        {
            if (employees == null)
            {
                employees = GetStandardEmployeeList();
            }
        }

        /// <summary>
        /// Private method GetStandardEmployeeList that returns List of Employee class
        /// Creates sample data with complex nested objects and collections
        /// </summary>
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 75000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Department = new Department { Id = 1, Name = "IT", Location = "Bangalore" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#", ExperienceYears = 5 },
                        new Skill { Id = 2, Name = "ASP.NET Core", ExperienceYears = 3 }
                    }
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 65000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1988, 8, 22),
                    Department = new Department { Id = 2, Name = "HR", Location = "Mumbai" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Recruitment", ExperienceYears = 4 },
                        new Skill { Id = 4, Name = "Training", ExperienceYears = 2 }
                    }
                },
                new Employee
                {
                    Id = 3,
                    Name = "Bob Johnson",
                    Salary = 55000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1992, 12, 10),
                    Department = new Department { Id = 3, Name = "Finance", Location = "Delhi" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 5, Name = "Accounting", ExperienceYears = 3 },
                        new Skill { Id = 6, Name = "Excel", ExperienceYears = 5 }
                    }
                }
            };
        }

        /// <summary>
        /// GET: api/employee
        /// Returns list of Employee class objects with ProducesResponseType for status code 200
        /// </summary>
        [HttpGet]
        [AllowAnonymous] // Use AllowAnonymous attribute as per requirements
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        /// <summary>
        /// GET: api/employee/standard
        /// Public ActionResult<Employee> GetStandard() as per requirements
        /// </summary>
        [HttpGet("standard")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return GetStandardEmployeeList();
        }

        /// <summary>
        /// GET: api/employee/{id}
        /// Returns specific employee by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Employee> Get(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");
            
            return Ok(employee);
        }

        /// <summary>
        /// POST: api/employee
        /// Creates new employee using FromBody attribute to read model object from request
        /// Demonstrates complex object binding with nested Department and Skills
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            if (string.IsNullOrEmpty(employee.Name))
                return BadRequest("Employee name is required");

            if (employee.Department == null)
                return BadRequest("Employee department is required");

            // Generate new ID
            employee.Id = employees.Max(e => e.Id) + 1;
            
            // Ensure Skills list is initialized
            if (employee.Skills == null)
                employee.Skills = new List<Skill>();

            employees.Add(employee);
            return Ok(employee);
        }

        /// <summary>
        /// PUT: api/employee/{id}
        /// Updates existing employee using FromBody attribute
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
                return NotFound($"Employee with ID {id} not found");

            if (employee == null)
                return BadRequest("Employee data is required");

            // Update employee properties
            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;
            existingEmployee.DateOfBirth = employee.DateOfBirth;
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills ?? new List<Skill>();

            return Ok(existingEmployee);
        }

        /// <summary>
        /// GET: api/employee/exception
        /// Throws an exception to test CustomExceptionFilter
        /// Ensures ProducesResponseType for 500 - Internal server error
        /// </summary>
        [HttpGet("exception")]
        [ProducesResponseType(500)]
        public ActionResult TestException()
        {
            // Throw an exception to test the custom exception filter
            throw new InvalidOperationException("This is a test exception to demonstrate CustomExceptionFilter");
        }

        /// <summary>
        /// DELETE: api/employee/{id}
        /// Deletes an employee
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");

            employees.Remove(employee);
            return Ok($"Employee {employee.Name} deleted successfully");
        }
    }
}
