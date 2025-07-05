using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab7_LINQ_Queries.Data;
using Lab7_LINQ_Queries.Models;
using Lab7_LINQ_Queries.DTOs;

// Lab 7: Writing Queries with LINQ
// Scenario: The store wants to filter and sort products for reporting
// Objective: Use Where, Select, OrderBy, and project into DTOs

namespace Lab7_LINQ_Queries
{
    class Program
    {
        static async Task Main()
        {
            using var context = new AppDbContext();

            var filtered = await context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            Console.WriteLine("Filtered and sorted products (Price > 1000):");
            foreach (var p in filtered)
                Console.WriteLine($"{p.Name} - {p.Price:N0}");

            var productDTOs = await context.Products
                .Select(p => new { p.Name, p.Price })
                .ToListAsync();

            Console.WriteLine("\nProduct DTOs (Name and Price):");
            foreach (var dto in productDTOs)
                Console.WriteLine($"{dto.Name} - {dto.Price:N0}");
        }
    }
}


