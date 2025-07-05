using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab3_Migrations.Data;

// Lab 3: EF Core Migrations
// Objective: Create and apply database migrations

namespace Lab3_Migrations
{
    class Program
    {
        static async Task Main()
        {
            using var context = new AppDbContext();

            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Check database connection
            var canConnect = await context.Database.CanConnectAsync();
            Console.WriteLine($"Database connected: {canConnect}");

            // Check applied migrations
            var appliedMigrations = await context.Database.GetAppliedMigrationsAsync();
            Console.WriteLine($"Applied migrations: {appliedMigrations.Count()}");

            // Check pending migrations
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            Console.WriteLine($"Pending migrations: {pendingMigrations.Count()}");

            if (pendingMigrations.Any())
            {
                Console.WriteLine("Run: dotnet ef database update");
            }
            else
            {
                Console.WriteLine("Database is up to date!");
            }
        }
    }
}
