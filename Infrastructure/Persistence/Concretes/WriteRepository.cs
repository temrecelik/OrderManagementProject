using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;
using Domain.Entities.Common;

namespace Persistence.Concretes;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity<Guid>
{
    private readonly OrderManagementDbContext _context;

    public WriteRepository(OrderManagementDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();


    public virtual async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public virtual async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }

    public virtual bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public virtual async Task<bool> RemoveAsync(Guid id)
    {
        T models = (await Table.FirstOrDefaultAsync(data => data.Id == id))!;
        return Remove(models);
    }

    public virtual bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }

    public virtual Task<bool> Update(T model)
    {
        EntityEntry<T> entityEntry = Table.Update(model);
        return Task.FromResult(entityEntry.State == EntityState.Modified);
    }
}