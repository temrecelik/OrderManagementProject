using Application.Repositories;
using Persistence.Contexts;

namespace Persistence.Concretes;

public class UnitOfWork<TIReadRepo, TIWriteRepo, TReadRepo, TWriteRepo> : IUnitOfWork<TIReadRepo, TIWriteRepo>
    where TReadRepo : TIReadRepo
    where TWriteRepo : TIWriteRepo
{
    private readonly OrderManagementDbContext _context;
    private readonly Lazy<TIReadRepo> _readRepo;
    private readonly Lazy<TIWriteRepo> _writeRepo;

    public UnitOfWork(OrderManagementDbContext context, Func<OrderManagementDbContext, TReadRepo> readRepoFactory, Func<OrderManagementDbContext, TWriteRepo> writeRepoFactory)
    {
        _context = context;
        _readRepo = new Lazy<TIReadRepo>(() => readRepoFactory(_context));
        _writeRepo = new Lazy<TIWriteRepo>(() => writeRepoFactory(_context));
    }

    public TIReadRepo ReadRepository => _readRepo.Value;
    public TIWriteRepo WriteRepository => _writeRepo.Value;

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
