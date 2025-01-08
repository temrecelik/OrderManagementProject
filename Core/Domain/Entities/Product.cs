using Domain.Entities.Common;

namespace Domain.Entities;

public class Product : BaseDescEntity<Guid>
{
    public int? StockCount { get; set; }
    public decimal Price { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public ICollection<Order>? Orders { get; set; }

    public Guid ProductCategoryId { get; set; }
    public ProductCategory? ProductCategory { get; set; }
}