using Domain.Entities.Common;

namespace Application.Tests.FakeDatas.Common;

public abstract class BaseFakeData<TEntity>
    where TEntity : BaseEntity<Guid>, new()
{
    public List<TEntity> Data => FakeData();
    public abstract List<TEntity> FakeData();
}