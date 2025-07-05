using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab1_Understanding_ORM.Data;
using Lab1_Understanding_ORM.Models;

// Lab 1: Understanding ORM with a Retail Inventory System
// Scenario: You're building an inventory management system for a retail store.
// The store wants to track products, categories, and stock levels in a SQL Server database.
// Objective: Understand what ORM is and how EF Core helps bridge the gap between C# objects and relational tables.

namespace Lab1_Understanding_ORM
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Lab 1: Understanding ORM with Retail Inventory System");
            Console.WriteLine("ORM maps C# classes to database tables");
            Console.WriteLine("EF Core: Cross-platform, lightweight, modern features");
            Console.WriteLine("EF Core 8.0: JSON mapping, compiled models, interceptors");
            Console.WriteLine();

            using var context = new AppDbContext();
            await context.Database.EnsureCreatedAsync();

            var categoryCount = await context.Categories.CountAsync();
            var productCount = await context.Products.CountAsync();
            Console.WriteLine($"Database: RetailStoreDB");
            Console.WriteLine($"Categories: {categoryCount}, Products: {productCount}");

            var expensiveProducts = await context.Products
                .Where(p => p.Price > 10000)
                .Include(p => p.Category)
                .ToListAsync();

            Console.WriteLine($"Expensive Products: {expensiveProducts.Count}");
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price:N0} ({product.Category.Name})");
            }
        }


    }
}
