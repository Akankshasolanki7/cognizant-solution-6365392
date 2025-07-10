namespace CustomModelsApi.Models
{
    /// <summary>
    /// Department model for nested object demonstration
    /// Part of complex Employee structure
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
