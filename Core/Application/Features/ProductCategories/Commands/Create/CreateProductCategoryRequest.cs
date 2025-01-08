using MediatR;

namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryRequest : IRequest<CreateProductCategoryResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}