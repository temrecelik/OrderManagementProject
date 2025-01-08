using Application.Repositories.ProductRepository;
using Persistence.Contexts;

namespace Persistence.Concretes.ProductRepository;

public class ProductUnitOfWork : UnitOfWork<IProductReadRepository, IProductWriteRepository, ProductReadRepository, ProductWriteRepository>, IProductUnitOfWork
{
    public ProductUnitOfWork(OrderManagementDbContext context)
        : base(context, ctx => new ProductReadRepository(ctx), ctx => new ProductWriteRepository(ctx))

    {
    }
}