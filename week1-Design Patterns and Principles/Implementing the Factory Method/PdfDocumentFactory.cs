public class PdfDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}
