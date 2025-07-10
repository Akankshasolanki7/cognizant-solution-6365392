using Microsoft.AspNetCore.Mvc;
using SwaggerWebApi.Models;

namespace SwaggerWebApi.Controllers
{
    /// <summary>
    /// Employee Controller demonstrating custom routing and ActionName usage
    /// Route changed from [controller] to 'Emp' for demonstration
    /// </summary>
    [ApiController]
    [Route("api/Emp")] // Custom route name instead of [controller]
    public class EmployeeController : ControllerBase
    {
        // Sample employee data for demonstration
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane Smith", Department = "HR", Salary = 45000 },
            new Employee { Id = 3, Name = "Bob Johnson", Department = "Finance", Salary = 55000 },
            new Employee { Id = 4, Name = "Alice Brown", Department = "Marketing", Salary = 48000 }
        };

        /// <summary>
        /// GET: api/Emp
        /// Returns all employees from the system
        /// </summary>
        /// <returns>List of all employees</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(500)]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        /// <summary>
        /// GET: api/Emp/1
        /// Returns a specific employee by ID
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Employee details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");
            
            return Ok(employee);
        }

        /// <summary>
        /// GET: api/Emp/active
        /// Returns only active employees (demonstration of ActionName)
        /// Shows how to have multiple GET methods with different routes
        /// </summary>
        /// <returns>List of active employees</returns>
        [HttpGet("active")]
        [ActionName("GetActiveEmployees")]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(500)]
        public IActionResult GetActiveEmployees()
        {
            // For demo, return employees with salary > 45000
            var activeEmployees = employees.Where(e => e.Salary > 45000).ToList();
            return Ok(activeEmployees);
        }

        /// <summary>
        /// GET: api/Emp/department/{dept}
        /// Returns employees by department (another ActionName example)
        /// </summary>
        /// <param name="dept">Department name</param>
        /// <returns>Employees in specified department</returns>
        [HttpGet("department/{dept}")]
        [ActionName("GetEmployeesByDepartment")]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetEmployeesByDepartment(string dept)
        {
            var deptEmployees = employees.Where(e => 
                e.Department.Equals(dept, StringComparison.OrdinalIgnoreCase)).ToList();
            
            if (!deptEmployees.Any())
                return NotFound($"No employees found in {dept} department");
            
            return Ok(deptEmployees);
        }

        /// <summary>
        /// POST: api/Emp
        /// Creates a new employee
        /// </summary>
        /// <param name="employee">Employee data</param>
        /// <returns>Created employee</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null || string.IsNullOrEmpty(employee.Name))
                return BadRequest("Invalid employee data");

            // Generate new ID
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            
            return Ok(employee);
        }

        /// <summary>
        /// PUT: api/Emp/1
        /// Updates an existing employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="employee">Updated employee data</param>
        /// <returns>Updated employee</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
                return NotFound($"Employee with ID {id} not found");

            if (employee == null || string.IsNullOrEmpty(employee.Name))
                return BadRequest("Invalid employee data");

            // Update employee
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;

            return Ok(existingEmployee);
        }

        /// <summary>
        /// DELETE: api/Emp/1
        /// Deletes an employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Success message</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");

            employees.Remove(employee);
            return Ok($"Employee {employee.Name} deleted successfully");
        }
    }
}
