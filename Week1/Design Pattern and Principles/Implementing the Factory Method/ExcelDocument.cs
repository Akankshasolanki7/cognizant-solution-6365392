using System;

public class ExcelDocument : IDocument
{
    public ExcelDocument()
    {
        Console.WriteLine("Excel Document Created");
    }

    public void Open()
    {
        Console.WriteLine("Opening the Excel");
    }

    public void Close()
    {
        Console.WriteLine("Closing the Excel");
    }
}
