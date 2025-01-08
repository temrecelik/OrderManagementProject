using Application.Repositories.UserRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.UserRepository;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(OrderManagementDbContext context) : base(context)
    {
    }
}