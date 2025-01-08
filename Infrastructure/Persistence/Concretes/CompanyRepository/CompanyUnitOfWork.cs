using Application.Repositories.CompanyRepository;
using Persistence.Contexts;

namespace Persistence.Concretes.CompanyRepository;

public class CompanyUnitOfWork : UnitOfWork<ICompanyReadRepository, ICompanyWriteRepository, CompanyReadRepository, CompanyWriteRepository>, ICompanyUnitOfWork
{
    public CompanyUnitOfWork(OrderManagementDbContext context)
        : base(context, ctx => new CompanyReadRepository(ctx), ctx => new CompanyWriteRepository(ctx))
    {
    }
}