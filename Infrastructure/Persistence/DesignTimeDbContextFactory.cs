using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrderManagementDbContext>
{
    public OrderManagementDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<OrderManagementDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString!);
        return new(dbContextOptionsBuilder.Options);
    }
}