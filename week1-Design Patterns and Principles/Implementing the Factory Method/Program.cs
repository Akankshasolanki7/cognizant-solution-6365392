using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("-----IMPLEMENTATION OF FACTORY METHOD PATTERN-----");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();

        Test();
    }

    public static void Test()
    {
        IDocument word = new WordDocumentFactory().CreateDocument();
        word.Open();
        word.Close();
        Console.WriteLine("-------------------------");

        IDocument pdf = new PdfDocumentFactory().CreateDocument();
        pdf.Open();
        pdf.Close();
        Console.WriteLine("-------------------------");

        IDocument excel = new ExcelDocumentFactory().CreateDocument();
        excel.Open();
        excel.Close();
        Console.WriteLine("-------------------------");
    }
}
