using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Commands.Create
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
		public ICollection<Guid>? ProductsId { get; set; }
	}
}
