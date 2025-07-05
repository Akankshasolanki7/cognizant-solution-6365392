using Microsoft.EntityFrameworkCore;
using Lab1_Understanding_ORM.Models;

namespace Lab1_Understanding_ORM.Data
{
    /// <summary>
    /// Database Context for the Retail Inventory System
    /// This class represents the bridge between C# objects and the database
    /// Demonstrates ORM concepts in action
    /// </summary>
    public class AppDbContext : DbContext
    {
        // DbSet properties represent database tables
        public DbSet<Product> Products { get; set; }     // Maps to Products table
        public DbSet<Category> Categories { get; set; }  // Maps to Categories table
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lab 1 Configuration - Use same database as other labs
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RetailStoreDB;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships (demonstrates ORM mapping)
            
            // Product-Category relationship (Many-to-One)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Configure decimal precision for Price
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // Seed initial data for demonstration
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Groceries" },
                new Category { Id = 3, Name = "Clothing" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 75000, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Price = 45000, CategoryId = 1 },
                new Product { Id = 3, Name = "Rice Bag", Price = 1200, CategoryId = 2 },
                new Product { Id = 4, Name = "T-Shirt", Price = 599, CategoryId = 3 }
            );
        }
    }
}
