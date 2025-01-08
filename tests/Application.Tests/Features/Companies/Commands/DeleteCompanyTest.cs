using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using Application.Tests.FakeDatas;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace Application.Tests.Features.Companies.Commands;

public class DeleteCompanyTest
{
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<ICompanyUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ICacheService> _cacheServiceMock = new();
    private readonly Mock<ICompanyBusinessRules> _businessRulesMock = new();
    private readonly DeleteCompanyHandler _handler;
    private readonly CompanyFakeData _fakeData = new();

    public DeleteCompanyTest()
    {
        _handler = new DeleteCompanyHandler(_mapperMock.Object, _unitOfWorkMock.Object, _cacheServiceMock.Object,
            _businessRulesMock.Object);
    }

    [Fact]
    public async Task DeleteCompanyHandler__GivenCompanyToDelete_ShouldReturnSuccessfulDeleteModel()
    {
        DeleteCompanyRequest request = new()
        {
            Id = _fakeData.FakeData()[0].Id
        };

        Company company = _fakeData.FakeData()[0];

        DeleteCompanyResponse response = new()
        {
            Name = company.Name
        };


        _unitOfWorkMock.Setup(x => x.ReadRepository.GetByIdAsync(request.Id)).ReturnsAsync(company);
        _unitOfWorkMock.Setup(x => x.WriteRepository.RemoveAsync(request.Id)).Returns(Task.FromResult(true));
        _mapperMock.Setup(m => m.Map<DeleteCompanyResponse>(company)).Returns(response);

        var companiesInCache = new List<Company> { company };
        _cacheServiceMock.Setup(x => x.GetAll<List<Company>>(CompaniesCacheKeys.Test)).Returns(companiesInCache);

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.Equal(response, result);

        _unitOfWorkMock.Verify(x => x.ReadRepository.GetByIdAsync(request.Id), Times.Once);
        _unitOfWorkMock.Verify(u => u.WriteRepository.RemoveAsync(request.Id), Times.Once);
        _mapperMock.Verify(m => m.Map<DeleteCompanyResponse>(company), Times.Once);

       


    }
}