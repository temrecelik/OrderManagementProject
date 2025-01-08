namespace Application.Repositories.ProductRepository;

public interface IProductUnitOfWork : IUnitOfWork<IProductReadRepository, IProductWriteRepository>
{
    
}