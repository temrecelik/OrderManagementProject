using Application.Repositories.CompanyRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.CompanyRepository;

public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
{
    private readonly OrderManagementDbContext _context;

    public CompanyReadRepository(OrderManagementDbContext context) : base(context)
    {
        _context = context;
    }

    public override IQueryable<Company> GetAll()
    {
        return _context.Set<Company>().Where(x=>x.Orders != null && x.Products != null).AsQueryable();
    }
}