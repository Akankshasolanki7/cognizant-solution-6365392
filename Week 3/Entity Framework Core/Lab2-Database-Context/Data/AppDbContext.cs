using Microsoft.EntityFrameworkCore;
using Lab2_Database_Context.Models;

namespace Lab2_Database_Context.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lab 2 Configuration - Main Database Context Setup
            // Connection String: Server + Database + Authentication + Security Settings
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RetailStoreDB;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }
    }
}
