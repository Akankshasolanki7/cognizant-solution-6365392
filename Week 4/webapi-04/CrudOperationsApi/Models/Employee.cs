using System.ComponentModel.DataAnnotations;

namespace CrudOperationsApi.Models
{
    /// <summary>
    /// Employee model for CRUD operations demonstration
    /// Enhanced with validation attributes and comprehensive properties
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        [StringLength(50, ErrorMessage = "Department cannot exceed 50 characters")]
        public string Department { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Join date is required")]
        public DateTime JoinDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
