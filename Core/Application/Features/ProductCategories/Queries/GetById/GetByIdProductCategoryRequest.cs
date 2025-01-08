using MediatR;

namespace Application.Features.ProductCategories.Queries.GetById;

public class GetByIdProductCategoryRequest : IRequest<GetByIdProductCategoryResponse>
{
    public GetByIdProductCategoryRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}