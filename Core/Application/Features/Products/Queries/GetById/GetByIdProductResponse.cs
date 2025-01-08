namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockCount { get; set; }
    public decimal Price { get; set; }
    public string CompanyName { get; set; }
    public string ProductCategoryName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
}