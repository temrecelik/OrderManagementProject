namespace Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : class
{
    Task<bool> AddAsync(T model);

    Task<bool> AddRangeAsync(List<T> datas);

    Task<bool> Update(T model);

    bool Remove(T model);

    bool RemoveRange(List<T> datas);

    Task<bool> RemoveAsync(Guid id);
}