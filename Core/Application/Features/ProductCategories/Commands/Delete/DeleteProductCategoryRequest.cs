using MediatR;

namespace Application.Features.ProductCategories.Commands.Delete;

public class DeleteProductCategoryRequest : IRequest<DeleteProductCategoryResponse>
{
    public Guid Id { get; set; }

    public DeleteProductCategoryRequest(Guid id)
    {
        Id = id;
    }
}