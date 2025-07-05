using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab6_Updating_Deleting.Data;
using Lab6_Updating_Deleting.Models;

namespace Lab6_Updating_Deleting
{
    class Program
    {
        static async Task Main()
        {
            using var context = new AppDbContext();

            var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            if (product != null)
            {
                product.Price = 70000;
                await context.SaveChangesAsync();
                Console.WriteLine($"Updated {product.Name} price to {product.Price:N0}");
            }

            var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
            if (toDelete != null)
            {
                context.Products.Remove(toDelete);
                await context.SaveChangesAsync();
                Console.WriteLine($"Deleted product: {toDelete.Name}");
            }

            var products = await context.Products.ToListAsync();
            Console.WriteLine("Current Products:");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - {p.Price:N0}");
        }
    }
}

