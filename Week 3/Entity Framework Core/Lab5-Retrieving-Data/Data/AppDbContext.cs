using Microsoft.EntityFrameworkCore;
using Lab5_Retrieving_Data.Models;

namespace Lab5_Retrieving_Data.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lab 5 Configuration - Use same database as Lab 2
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RetailStoreDB;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }
    }
}
