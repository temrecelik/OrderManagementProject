using Application.Repositories.ProductRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.ProductRepository;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(OrderManagementDbContext context) : base(context)
    {
    }
}