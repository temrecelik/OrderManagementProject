using Application.Excepetions;
using Application.Repositories.OrderRepository;
using Application.Repositories.ProductRepository;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.Create
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderUnitOfWork _unitOfWork;
        private readonly IProductUnitOfWork _productUnitOfWork;

        public CreateOrderHandler(IMapper mapper, IOrderUnitOfWork unitOfWork, IProductUnitOfWork productUnitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productUnitOfWork = productUnitOfWork;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = _mapper.Map<Order>(request);

            List<Product> Products = new List<Product>();

            foreach (var item in request.ProductsId)
            {
                var product = await _productUnitOfWork.ReadRepository.GetByIdAsync(item);
                if (product.CompanyId == request.CompanyId)
                {
                    Products.Add(product);
                }
                else
                {
                    throw new BusinessException("");
                }
            }

            //order.Products = Products;
            order.OrderStatus = OrderStatus.Successfull;
            order.TotalPrice = (decimal)(order.UnitPrice * order.ProductCount)!;

            await _unitOfWork.WriteRepository.AddAsync(order);

            await _unitOfWork.SaveAsync();

            CreateOrderResponse response = _mapper.Map<CreateOrderResponse>(order);
            return response;

        }
    }
}
