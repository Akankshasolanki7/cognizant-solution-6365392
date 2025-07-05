namespace Lab1_Understanding_ORM.Models
{
    /// <summary>
    /// Represents a product category in the retail inventory system
    /// This C# class maps to the Categories table in the database
    /// </summary>
    public class Category
    {
        public int Id { get; set; }                           // Primary Key → Categories.Id
        public string Name { get; set; } = string.Empty;     // → Categories.Name (nvarchar)
        public List<Product> Products { get; set; } = new List<Product>(); // Navigation Property → One-to-Many relationship
    }
}
