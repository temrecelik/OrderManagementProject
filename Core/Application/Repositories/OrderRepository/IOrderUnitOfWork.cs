namespace Application.Repositories.OrderRepository;

public interface IOrderUnitOfWork : IUnitOfWork<IOrderReadRepository, IOrderWriteRepository>
{
    
}