namespace Application.Repositories;

public interface IUnitOfWork<out TIReadRepo, out TIWriteRepo>
{
    TIReadRepo ReadRepository { get; }
    TIWriteRepo WriteRepository { get; }

    Task<int> SaveAsync();
}