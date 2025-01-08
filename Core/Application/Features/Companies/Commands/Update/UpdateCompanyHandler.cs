using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
{

    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
	private readonly ICompanyBusinessRules _businessRules;
	private readonly ICacheService _cacheService;

	public UpdateCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICompanyBusinessRules businessRules, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
		_cacheService = cacheService;
	}

	public async Task<UpdateCompanyResponse> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.CompanyIdShouldExistWhenSelected(request.Id);
        await _businessRules.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name);

        var mappedCompany = _mapper.Map<Company>(request);
        await _unitOfWork.WriteRepository.Update(mappedCompany);
		await _unitOfWork.SaveAsync();

		List<Company> companiesInCache = _cacheService.GetAll<List<Company>>(CompaniesCacheKeys.AllCompanies);
		companiesInCache.RemoveAll(c => c.Id == request.Id);
		companiesInCache.Add(mappedCompany);
		_cacheService.Set(CompaniesCacheKeys.AllCompanies, companiesInCache, TimeSpan.FromMinutes(2));

		var  response = _mapper.Map<UpdateCompanyResponse>(mappedCompany);
        return response;
    }
}