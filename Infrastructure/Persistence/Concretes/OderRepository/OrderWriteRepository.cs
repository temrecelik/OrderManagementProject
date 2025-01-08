using Application.Repositories.OrderRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.OderRepository;

public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(OrderManagementDbContext context) : base(context)
    {
    }
}