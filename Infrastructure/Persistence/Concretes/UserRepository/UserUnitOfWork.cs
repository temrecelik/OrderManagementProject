using Application.Repositories.UserRepository;
using Persistence.Contexts;

namespace Persistence.Concretes.UserRepository;

public class UserUnitOfWork : UnitOfWork<IUserReadRepository, IUserWriteRepository, UserReadRepository, UserWriteRepository>, IUserUnitOfWork
{
    public UserUnitOfWork(OrderManagementDbContext context)
        : base(context, ctx => new UserReadRepository(ctx), ctx => new UserWriteRepository(ctx))

    {
    }
}