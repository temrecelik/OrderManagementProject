using MediatR;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductRequest : IRequest<GetByIdProductResponse>
{
    public GetByIdProductRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}