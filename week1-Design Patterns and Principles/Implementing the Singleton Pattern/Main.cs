using System;

public class Program
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        if (logger1 == logger2)
        {
            Console.WriteLine("Both the logger instances are the same");
        }
        else
        {
            Console.WriteLine("Logger instances are not same");
        }

        Console.WriteLine();

        LoggerTest(logger1, logger2);
    }

    public static void LoggerTest(Logger logger1, Logger logger2)
    {
        logger1.SetUsernameAndPassword("anku", "12345");
        logger2.SetUsernameAndPassword("khush", "55678");

        Console.WriteLine("Logger 1 credentials:");
        logger1.DisplayCredentials();
        Console.WriteLine("-------------------------");
        Console.WriteLine("Logger 2 credentials:");
        logger2.DisplayCredentials();

        Console.WriteLine("\nBoth credentials will be the same because both are the same instance.");
    }
}

