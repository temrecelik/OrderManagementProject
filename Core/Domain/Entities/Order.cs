using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public int? ProductCount { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus? OrderStatus { get; set; }


    public ICollection<Product>? Products { get; set; } = new List<Product>();

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}