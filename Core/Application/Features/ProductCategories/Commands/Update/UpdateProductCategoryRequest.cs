using MediatR;

namespace Application.Features.ProductCategories.Commands.Update;

public class UpdateProductCategoryRequest : IRequest<UpdateProductCategoryResponse>
{
    public Guid Id { get; set; }
	public string Name { get; set; }

}