namespace Application.Features.ProductCategories.Queries.GetById;

public class GetByIdProductCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
}