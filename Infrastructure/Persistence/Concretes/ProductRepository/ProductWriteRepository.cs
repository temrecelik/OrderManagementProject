using Application.Repositories.ProductRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.ProductRepository;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(OrderManagementDbContext context) : base(context)
    {
    }
}