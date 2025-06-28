using System;

public class WordDocument : IDocument
{
    public WordDocument()
    {
        Console.WriteLine("Word Document Created");
    }

    public void Open()
    {
        Console.WriteLine("Opening the Word");
    }

    public void Close()
    {
        Console.WriteLine("Closing the Word");
    }
}
