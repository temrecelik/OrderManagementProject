using Application.Repositories.ProductCategoryRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.ProductCategoryRepository;

public class ProductCategoryWriteRepository : WriteRepository<ProductCategory>, IProductCategoryWriteRepository
{
    public ProductCategoryWriteRepository(OrderManagementDbContext context) : base(context)
    {
    }
}