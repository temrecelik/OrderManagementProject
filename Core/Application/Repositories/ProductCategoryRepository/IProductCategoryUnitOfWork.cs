namespace Application.Repositories.ProductCategoryRepository;

public interface IProductCategoryUnitOfWork : IUnitOfWork<IProductCategoryReadRepository, IProductCategoryWriteRepository>
{
    
}