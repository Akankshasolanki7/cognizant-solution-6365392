using System;

public class Program
{
    public static double FutureValue(double principal, double rate, int years)
    {
        if (years == 0)
        {
            return principal;
        }
        return FutureValue(principal, rate, years - 1) * (1 + rate);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Financial Forecasting");
        Console.WriteLine("---------------------");

        Console.Write("\nEnter the Principal Amount: ");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nEnter the Growth Rate (e.g., 0.05 for 5%): ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nEnter the Number of Years: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double result = FutureValue(principal, rate, years);
        Console.WriteLine($"\nFuture value after {years} years: {result:F2}");
    }
}
