namespace Application.Repositories.UserRepository;

public interface IUserUnitOfWork : IUnitOfWork<IUserReadRepository, IUserWriteRepository>
{
    
}