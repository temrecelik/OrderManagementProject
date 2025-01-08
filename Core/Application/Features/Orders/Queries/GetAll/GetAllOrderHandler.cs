using Application.Repositories.OrderRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderRequest, List<GetAllOrderResponse>>
    {
        
        private readonly IMapper _mapper;
        private readonly IOrderUnitOfWork _unitOfWork;

		public GetAllOrderHandler(IMapper mapper, IOrderUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public Task<List<GetAllOrderResponse>> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
        {

            List<Order> order = _unitOfWork.ReadRepository.GetAll().ToList();

            List<GetAllOrderResponse> response = _mapper.Map<List<GetAllOrderResponse>>(order);

            return Task.FromResult(response);
        }
    }
}
