using System;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Shop shop = new Shop();
        int productIndex;
        Stopwatch stopwatch = new Stopwatch();

        shop.StoreProducts();

        Console.WriteLine("Linear Search:");
        stopwatch.Start();
        productIndex = shop.LinearSearch(8);
        stopwatch.Stop();
        shop.DisplayProduct(productIndex);
        Console.WriteLine("Time Taken: " + stopwatch.ElapsedTicks + " ticks");
        Console.WriteLine("--------------------------------------");

        Console.WriteLine("Binary Search:");
        stopwatch.Restart();
        productIndex = shop.BinarySearch(8);
        stopwatch.Stop();
        shop.DisplayProduct(productIndex);
        Console.WriteLine("Time Taken: " + stopwatch.ElapsedTicks + " ticks");
    }
}
