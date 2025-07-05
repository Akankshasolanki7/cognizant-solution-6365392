using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab2_Database_Context.Data;

// Lab 2: Setting Up the Database Context for a Retail Store
// Scenario: Configure DbContext and connect to SQL Server
// Objective: Create database and tables using EF Core

namespace Lab2_Database_Context
{
    class Program
    {
        static async Task Main()
        {
            using var context = new AppDbContext();

            // Create database and tables
            await context.Database.EnsureCreatedAsync();
            Console.WriteLine("Database created successfully!");

            // Test connection
            var canConnect = await context.Database.CanConnectAsync();
            Console.WriteLine($"Database connected: {canConnect}");

            // Display database info
            Console.WriteLine($"Database: {context.Database.GetDbConnection().Database}");
            Console.WriteLine($"Server: {context.Database.GetDbConnection().DataSource}");
            Console.WriteLine("Tables created: Products, Categories");
        }
    }
}
