using MediatR;

namespace Application.Features.Orders.Queries.GetById
{
    public class GetByIdOrderRequest : IRequest <GetByIdOrderResponse>
    {
        public Guid Id { get; set; }

        public GetByIdOrderRequest(Guid id)
        {
            Id = id;
        }
    }
}
