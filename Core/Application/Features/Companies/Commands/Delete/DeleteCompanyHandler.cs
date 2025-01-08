using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Delete;

public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyRequest, DeleteCompanyResponse>
{
    
    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
    private readonly ICompanyBusinessRules _businessRules;
    private readonly ICacheService _cacheService;

	public DeleteCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICacheService cacheService, ICompanyBusinessRules businessRules)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_cacheService = cacheService;
        _businessRules = businessRules;
    }

	public async Task<DeleteCompanyResponse> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.CompanyIdShouldExistWhenSelected(request.Id);

        Company mappedCompany = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await _unitOfWork.WriteRepository.RemoveAsync(request.Id);
		await _unitOfWork.SaveAsync();

		List<Company> companiesInCache = _cacheService.GetAll<List<Company>>(CompaniesCacheKeys.AllCompanies);
		companiesInCache.RemoveAll(c => c.Id == request.Id);
        _cacheService.Set(CompaniesCacheKeys.AllCompanies, companiesInCache, TimeSpan.FromMinutes(1));

		DeleteCompanyResponse response = _mapper.Map<DeleteCompanyResponse>(mappedCompany);
        return response;
    }
}