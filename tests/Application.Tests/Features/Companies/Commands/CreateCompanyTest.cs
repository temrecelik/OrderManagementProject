using Application.Excepetions;
using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using Application.Tests.FakeDatas;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace Application.Tests.Features.Companies.Commands;

public class CreateCompanyTest
{
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<ICompanyUnitOfWork> _unitOfWorkMock = new(); 
    private readonly Mock<ICacheService> _cacheServiceMock = new();
    private readonly Mock<ICompanyBusinessRules> _businessRulesMock = new();
    private readonly CreateCompanyHandler _handler;
	private readonly CompanyFakeData _fakeData = new();

    public CreateCompanyTest()
    {
        _handler = new CreateCompanyHandler(_mapperMock.Object, _unitOfWorkMock.Object,  _businessRulesMock.Object, _cacheServiceMock.Object);
    }

    [Fact]//Başarılı şirket ekleme işleminin test edilmesi.
    public async Task CreateCompanyHandler_GivenCompanyToCreate_ShouldReturnSuccessfulCompanyModel()
    {
        // Arrange - Düzenlemek
        CreateCompanyRequest request = new()
        {
            Name = "Test",
            Description = "Test"
        };
            
        var response = new CreateCompanyResponse
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
        };

        _mapperMock.Setup(x => x.Map<Company>(request)).Returns(new Company());
        _unitOfWorkMock.Setup(x => x.WriteRepository.AddAsync(It.IsAny<Company>())).Returns(Task.FromResult(true));
        _mapperMock.Setup(x => x.Map<CreateCompanyResponse>(It.IsAny<Company>())).Returns(response);

		_cacheServiceMock.Setup(x => x.GetAll<List<Company>>(CompaniesCacheKeys.Test)).Returns(new List<Company>());
		_cacheServiceMock.Setup(x => x.Set(CompaniesCacheKeys.Test, It.IsAny<List<Company>>(), TimeSpan.FromMinutes(1))).Verifiable();
		_cacheServiceMock.Setup(x => x.Remove(CompaniesCacheKeys.Test)).Verifiable();

		// Act - Davranmak
		var result = await _handler.Handle(request, CancellationToken.None);

        // Assert - İleri Sürmek
        Assert.Equal(response, result);

        _mapperMock.Verify(m => m.Map<Company>(request), Times.Once);
        _unitOfWorkMock.Verify(u => u.WriteRepository.AddAsync(It.IsAny<Company>()), Times.Once);
        _mapperMock.Verify(m => m.Map<CreateCompanyResponse>(It.IsAny<Company>()), Times.Once);

		
	}

    [Fact]//Aynı isimde şirketin hata vermesinin test edilmesi
    public async Task CreateCompanyHandler_GivenExistingCompanyName_ShouldThrowException()
    {
        CreateCompanyRequest request = new()
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