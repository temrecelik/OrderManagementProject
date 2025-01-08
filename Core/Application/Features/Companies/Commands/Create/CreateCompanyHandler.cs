using Application.Aspects.Autofac.Validation;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
    private readonly ICompanyBusinessRules _businessRules;
    private readonly ICacheService _cacheService;

    public CreateCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICompanyBusinessRules businessRules, ICacheService cacheService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
        _cacheService = cacheService;
    }


    [ValidationAspect(typeof(CreateCompanyRequestValidator))]
    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name);

        Company mappedCompany = _mapper.Map<Company>(request);
        await _unitOfWork.WriteRepository.AddAsync(mappedCompany);
        await _unitOfWork.SaveAsync();

        List<Company> companiesInCache = _cacheService.GetAll<List<Company>>(CompaniesCacheKeys.AllCompanies);
       companiesInCache.Add(mappedCompany);
        _cacheService.Set(CompaniesCacheKeys.AllCompanies, companiesInCache, TimeSpan.FromMinutes(1));
        _cacheService.Remove(CompaniesCacheKeys.AllCompanies);

        CreateCompanyResponse response = _mapper.Map<CreateCompanyResponse>(mappedCompany);
        return response;
    }
}