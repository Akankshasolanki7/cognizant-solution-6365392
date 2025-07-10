namespace JwtAuthApi.Models
{
    /// <summary>
    /// Employee model for JWT authentication demonstration
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
