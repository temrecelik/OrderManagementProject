namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}