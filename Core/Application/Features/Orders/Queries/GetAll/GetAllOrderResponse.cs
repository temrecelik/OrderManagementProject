using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrderResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int? OrderCount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public Company? Company { get; set; }
        public Product? Product { get; set; }
        public User? User { get; set; }
    }
}
