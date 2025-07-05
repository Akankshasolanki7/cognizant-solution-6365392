namespace Lab7_LINQ_Queries.DTOs
{
    // Lab 7: Data Transfer Objects for clean data presentation
    public class ProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class ProductSummaryDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PriceRange { get; set; } = string.Empty;
    }

    public class CategoryReportDTO
    {
        public string CategoryName { get; set; } = string.Empty;
        public int ProductCount { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class ExpensiveProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string FormattedPrice { get; set; } = string.Empty;
    }
}
