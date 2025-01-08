using Application.Repositories.UserRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.UserRepository;

public class UserReadRepository : ReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(OrderManagementDbContext context) : base(context)
    {
    }
}