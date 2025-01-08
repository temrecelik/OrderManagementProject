namespace Application.Features.Products.Commands.Update;

public class UpdateProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}