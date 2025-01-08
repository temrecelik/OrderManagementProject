using Application.Repositories.OrderRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Queries.GetById
{
    public class GetByIdOrderHandler : IRequestHandler<GetByIdOrderRequest, GetByIdOrderResponse>
    {
      
        private readonly IMapper _mapper;
        private readonly IOrderUnitOfWork _unitOfWork;

		public GetByIdOrderHandler(IMapper mapper, IOrderUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<GetByIdOrderResponse> Handle(GetByIdOrderRequest request, CancellationToken cancellationToken)
        {

            Order order = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            GetByIdOrderResponse response = _mapper.Map<GetByIdOrderResponse>(order);
            
            return response;
        }
    }
}
