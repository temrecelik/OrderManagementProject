using Application.Repositories.OrderRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.OderRepository;

public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(OrderManagementDbContext context) : base(context)
    {
    }
}