public class ExcelDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new ExcelDocument();
    }
}
