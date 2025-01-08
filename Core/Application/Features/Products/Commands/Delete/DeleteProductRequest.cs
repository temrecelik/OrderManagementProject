using MediatR;

namespace Application.Features.Products.Commands.Delete
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public DeleteProductRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
