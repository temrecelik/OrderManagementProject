using Application.Repositories.CompanyRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.CompanyRepository;

public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
{
    public CompanyWriteRepository(OrderManagementDbContext context) : base(context)
    {
    }
}