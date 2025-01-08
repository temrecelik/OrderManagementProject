using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;
using Domain.Entities.Common;

namespace Persistence.Concretes;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity<Guid>
{
    private readonly OrderManagementDbContext _context;

    public ReadRepository(OrderManagementDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();


    public virtual IQueryable<T> GetAll() => Table.AsQueryable();

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return (await Table.FirstOrDefaultAsync(data => data.Id == id))!;
    }

    public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => (await Table.FirstOrDefaultAsync(method))!;

    public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);
}