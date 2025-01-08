using Application.Repositories.OrderRepository;
using Persistence.Contexts;

namespace Persistence.Concretes.OderRepository;

public class OrderUnitOfWork : UnitOfWork<IOrderReadRepository, IOrderWriteRepository, OrderReadRepository, OrderWriteRepository>, IOrderUnitOfWork
{
    public OrderUnitOfWork(OrderManagementDbContext context)
        : base(context, ctx => new OrderReadRepository(ctx), ctx => new OrderWriteRepository(ctx))

    {
    }
}