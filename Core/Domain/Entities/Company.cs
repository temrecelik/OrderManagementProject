using Domain.Entities.Common;

namespace Domain.Entities;

public class Company : BaseDescEntity<Guid>
{
    public ICollection<Product>? Products { get; set; }
    public ICollection<Order>? Orders { get; set; }
}