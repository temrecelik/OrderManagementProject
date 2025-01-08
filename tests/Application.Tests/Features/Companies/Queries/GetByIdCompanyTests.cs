using Application.Features.Companies.Constants;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using Application.Tests.FakeDatas;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace Application.Tests.Features.Companies.Queries;

public class GetByIdCompanyTests
{
	private readonly Mock<IMapper> _mapperMock = new();
	private readonly Mock<ICompanyUnitOfWork> _unitOfWorkMock = new();
	private readonly Mock<ICacheService> _cacheServiceMock = new();
	private readonly Mock<ICompanyBusinessRules> _businessRulesMock = new();
	private readonly GetByIdCompanyHandler _handler;
	private readonly CompanyFakeData _companyFakeData = new();

	public GetByIdCompanyTests()
	{
		_handler = new GetByIdCompanyHandler(_mapperMock.Object, _unitOfWorkMock.Object, _cacheServiceMock.Object, _businessRulesMock.Object);
	}

	[Fact]
	public async Task GetByIdCompanyShouldSuccessfuly()
	{
		var request = new GetByIdCompanyRequest
		{
			Id = Guid.NewGuid()
		};

		var company = _companyFakeData.FakeData()[0];

		var response = new GetByIdCompanyResponse
		{
			Id = company.Id,
			Name = company.Name,
			Description = company.Description!,
			CreatedDate = company.CreatedDate,
			LastUpdatedDate = company.LastUpdatedDate
		};

		_unitOfWorkMock.Setup(x => x.ReadRepository.GetByIdAsync(request.Id)).ReturnsAsync(company);
		_mapperMock.Setup(x => x.Map<GetByIdCompanyResponse>(It.IsAny<Company>())).Returns(response);

        _cacheServiceMock.Setup(x => x.GetAll<GetByIdCompanyResponse>(CompaniesCacheKeys.Test)).Returns((GetByIdCompanyResponse)null!);

        var result = await _handler.Handle(request, CancellationToken.None);

		Assert.Equal(response, result);

		_unitOfWorkMock.Verify(r => r.ReadRepository.GetByIdAsync(request.Id), Times.Once);
		_mapperMock.Verify(m => m.Map<GetByIdCompanyResponse>(company), Times.Once);
	}
}