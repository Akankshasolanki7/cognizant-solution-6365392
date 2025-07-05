namespace Lab1_Understanding_ORM.Models
{
    /// <summary>
    /// Represents a product in the retail inventory system
    /// This C# class maps to the Products table in the database
    /// </summary>
    public class Product
    {
        public int Id { get; set; }                      // Primary Key → Products.Id
        public string Name { get; set; } = string.Empty; // → Products.Name (nvarchar)
        public decimal Price { get; set; }               // → Products.Price (decimal)
        public int CategoryId { get; set; }              // Foreign Key → Products.CategoryId
        public Category Category { get; set; } = null!; // Navigation Property → Many-to-One relationship
    }
}
