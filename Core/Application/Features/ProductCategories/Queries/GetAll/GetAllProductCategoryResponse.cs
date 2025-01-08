namespace Application.Features.ProductCategories.Queries.GetAll;

public class GetAllProductCategoryResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
}