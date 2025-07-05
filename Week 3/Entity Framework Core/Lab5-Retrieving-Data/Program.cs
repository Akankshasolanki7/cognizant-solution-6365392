using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab5_Retrieving_Data.Data;
using Lab5_Retrieving_Data.Models;

class Program
{
   static async Task Main()
   {
       using var context = new AppDbContext();

       var products = await context.Products.ToListAsync();
       foreach (var p in products)
           Console.WriteLine($"{p.Name} - {p.Price:N0}");

       var product = await context.Products.FindAsync(1);
       Console.WriteLine($"Found: {product?.Name}");

       var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
       Console.WriteLine($"Expensive: {expensive?.Name}");
   }
}