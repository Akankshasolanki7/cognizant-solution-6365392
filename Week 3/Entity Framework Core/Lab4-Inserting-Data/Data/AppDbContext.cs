using Microsoft.EntityFrameworkCore;
using Lab4_Inserting_Data.Models;

namespace Lab4_Inserting_Data.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lab 4 Configuration - Use same database as other labs
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RetailStoreDB;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }
    }
}
