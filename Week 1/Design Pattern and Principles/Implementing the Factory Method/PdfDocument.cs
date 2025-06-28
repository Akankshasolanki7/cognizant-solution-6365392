using System;

public class PdfDocument : IDocument
{
    public PdfDocument()
    {
        Console.WriteLine("PDF Document Created");
    }

    public void Open()
    {
        Console.WriteLine("Opening the PDF");
    }

    public void Close()
    {
        Console.WriteLine("Closing the PDF");
    }
}
