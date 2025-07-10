namespace CustomModelsApi.Models
{
    /// <summary>
    /// Employee model with complex structure as per requirements
    /// Demonstrates custom class entity with nested objects and collections
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public Department Department { get; set; } = new Department();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public DateTime DateOfBirth { get; set; }
    }
}
