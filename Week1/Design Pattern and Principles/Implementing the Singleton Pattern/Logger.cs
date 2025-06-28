using System;

public class Logger
{
    private static Logger loggerInstance;

    private string username;
    private string password;

    // Private constructor to prevent external instantiation
    private Logger() {}

    // Public method to get the single instance
    public static Logger GetInstance()
    {
        if (loggerInstance == null)
        {
            loggerInstance = new Logger();
        }
        return loggerInstance;
    }

    // Method to set credentials
    public void SetUsernameAndPassword(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    // Method to display credentials
    public void DisplayCredentials()
    {
        Console.WriteLine("Username: " + username);
        Console.WriteLine("Password: " + password);
    }
}
