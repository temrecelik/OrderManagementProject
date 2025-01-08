using Application.Repositories.CompanyRepository;
using Microsoft.EntityFrameworkCore;
using Application.Excepetions;
using Application.Features.Companies.Constants;
using Domain.Entities;

namespace Application.Features.Companies.Rules
{
    public class CompanyBusinessRules : ICompanyBusinessRules
    {
        private readonly ICompanyUnitOfWork _companyUnitOfWork;

        public CompanyBusinessRules(ICompanyUnitOfWork companyUnitOfWork)
        {
            _companyUnitOfWork = companyUnitOfWork;
        }

        public void CompanyIdShouldExistWhenSelected(Company? company)
        {
            if (company == null)
                throw new BusinessException(CompaniesMessages.CompanyNotExists);
        }

        public async Task CompanyIdShouldExistWhenSelected(Guid id)
        {
            Company company = await _companyUnitOfWork.ReadRepository.GetByIdAsync(id);
            CompanyIdShouldExistWhenSelected(company);
        }

        public async Task CompanyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            Company? company = await _companyUnitOfWork.ReadRepository.GetAll().FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());

            if (company != null)
                throw new BusinessException(CompaniesMessages.CompanyNameExists);
        }
    }
}
