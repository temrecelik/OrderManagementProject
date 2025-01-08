namespace Application.Repositories.CompanyRepository;

public interface ICompanyUnitOfWork : IUnitOfWork<ICompanyReadRepository, ICompanyWriteRepository>
{
    
}