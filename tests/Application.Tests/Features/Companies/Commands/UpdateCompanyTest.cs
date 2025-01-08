using Application.Excepetions;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using Application.Tests.FakeDatas;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace Application.Tests.Features.Companies.Commands;

public class UpdateCompanyTest
{
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<ICompanyUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ICompanyBusinessRules> _businessRulesMock = new();
    private readonly Mock<ICacheService> _cacheServiceMock = new();
    private readonly UpdateCompanyHandler _handler;
    private readonly CompanyFakeData _fakeData = new();

    public UpdateCompanyTest()
    {
        _handler = new UpdateCompanyHandler(_mapperMock.Object, _unitOfWorkMock.Object, _businessRulesMock.Object, _cacheServiceMock.Object);
    }

    [Fact]
    public async Task UpdateCompanyHandler_GivenCompanyToUpdate_ShouldReturnSuccessfulUpdateModel()
    {
        UpdateCompanyRequest request = new()
        {
            Id = new Guid(),
            Name = "UpdateTest",
            Description = "UpdateTest"
        };

        Company company = _fakeData.FakeData()[0];

        UpdateCompanyResponse response = new()
        {
            Name = request.Name,
            Description = request.Description
        };

        _mapperMock.Setup(x => x.Map<Company>(request)).Returns(company);
        _unitOfWorkMock.Setup(x => x.WriteRepository.Update(company)).Returns(Task.FromResult(true));
        _mapperMock.Setup(x => x.Map<UpdateCompanyResponse>(company)).Returns(response);

        _cacheServiceMock.Setup(x => x.GetAll<List<Company>>(CompaniesCacheKeys.AllCompanies)).Returns(new List<Company> { company });

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.Equal(result, response);

        _mapperMock.Verify(x => x.Map<Company>(request), Times.Once);
        _unitOfWorkMock.Verify(x => x.WriteRepository.Update(company), Times.Once);
        _mapperMock.Verify(x => x.Map<UpdateCompanyResponse>(company), Times.Once);
    }

    [Fact]
    public async Task UpdateCompanyHandler_GivenExistingCompanyName_ShouldThrowException()
    {
        UpdateCompanyRequest request = new()
        {
            Name = "Fake 1",
            Description = "Fake 1"
        };

        var companies = _fakeData.FakeData();

        _unitOfWorkMock.Setup(x => x.ReadRepository.GetAll()).Returns(new List<Company> { companies[0] }.AsQueryable());

        _businessRulesMock.Setup(x => x.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name))
            .ThrowsAsync(new BusinessException(CompaniesMessages.CompanyNameExists));

        await Assert.ThrowsAsync<BusinessException>(async () =>
            await _businessRulesMock.Object.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name));

        _mapperMock.Verify(m => m.Map<Company>(request), Times.Never);
        _unitOfWorkMock.Verify(u => u.WriteRepository.AddAsync(It.IsAny<Company>()), Times.Never);
    }
}