using Domain.Entities;

namespace Application.Features.Companies.Rules;

public interface ICompanyBusinessRules
{
    void CompanyIdShouldExistWhenSelected(Company company);
    Task CompanyIdShouldExistWhenSelected(Guid id);
    Task CompanyNameCanNotBeDuplicatedWhenInserted(string name);
}