using Microsoft.EntityFrameworkCore;
using Lab6_Updating_Deleting.Models;

namespace Lab6_Updating_Deleting.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lab 6 Configuration - Use same database as other labs
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RetailStoreDB;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }
    }
}
