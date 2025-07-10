namespace SwaggerWebApi.Models
{
    /// <summary>
    /// Employee model for demonstration
    /// Simple class representing an employee entity
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
