using Domain.Entities.Common;

namespace Domain.Entities;

public class ProductCategory : BaseDescEntity<Guid>
{
    public ICollection<Product>? Products { get; set; }
}