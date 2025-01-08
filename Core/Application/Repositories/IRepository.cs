using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public interface IRepository<T> where T : class
{
    DbSet<T> Table { get; }
}