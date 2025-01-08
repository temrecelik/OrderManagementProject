using MediatR;

namespace Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrderRequest :IRequest<List<GetAllOrderResponse>>
    {
        
    }
}
