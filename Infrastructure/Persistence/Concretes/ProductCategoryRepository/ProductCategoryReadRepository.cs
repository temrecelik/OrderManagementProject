using Application.Repositories.ProductCategoryRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.ProductCategoryRepository;

public class ProductCategoryReadRepository : ReadRepository<ProductCategory>, IProductCategoryReadRepository
{
    public ProductCategoryReadRepository(OrderManagementDbContext context) : base(context)
    {
    }
}