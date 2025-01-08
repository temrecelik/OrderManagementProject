using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Queries.GetAll;
using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Moq;
using System;
using Application.Features.Companies.Constants;

namespace Application.Tests.Features.Companies.Queries;

public class GetAllCompanyTests
{
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<ICompanyUnitOfWork> _unitOfWorkMock = new();
    private readonly GetAllCompanyHandler _handler;
    private readonly Mock<ICacheService> _cacheServiceMock = new();

    public GetAllCompanyTests()
    {
        _handler = new GetAllCompanyHandler(_mapperMock.Object, _unitOfWorkMock.Object, _cacheServiceMock.Object);
    }

    [Fact]
    public async Task GetAllBrandsShouldSuccessfuly()
    {
        var companies = new List<Company>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test 1",
                Description = "Test 1",
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow
            }
        };

        var response = new List<GetAllCompanyResponse>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test 1",
                Description = "Test 1",
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow
            }
        };

        _unitOfWorkMock.Setup(x => x.ReadRepository.GetAll()).Returns(companies.AsQueryable());
        _mapperMock.Setup(x => x.Map<List<GetAllCompanyResponse>>(It.IsAny<List<Company>>())).Returns(response);

        _cacheServiceMock.Setup(x => x.GetAll<List<GetAllCompanyResponse>>(CompaniesCacheKeys.Test));
        _cacheServiceMock.Setup(x => x.Set(CompaniesCacheKeys.Test, response, TimeSpan.FromHours(1)));

        var result = await _handler.Handle(new GetAllCompanyRequest(), CancellationToken.None);

        Assert.Equal(response, result);

        _unitOfWorkMock.Verify(x => x.ReadRepository.GetAll(), Times.Once);
        _mapperMock.Verify(x => x.Map<List<GetAllCompanyResponse>>(companies), Times.Once);
    }
}