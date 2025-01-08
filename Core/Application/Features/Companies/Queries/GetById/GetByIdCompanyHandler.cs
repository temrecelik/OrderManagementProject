using Application.Features.Companies.Constants;
using Application.Features.Companies.Rules;
using Application.Repositories.CompanyRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Queries.GetById;

public class GetByIdCompanyHandler : IRequestHandler<GetByIdCompanyRequest, GetByIdCompanyResponse>
{

    private readonly IMapper _mapper;
    private readonly ICompanyUnitOfWork _unitOfWork;
	private readonly ICompanyBusinessRules _businessRules;
    private readonly ICacheService _cacheService;
	

	public GetByIdCompanyHandler(IMapper mapper, ICompanyUnitOfWork unitOfWork, ICacheService cacheService, ICompanyBusinessRules businessRules)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_cacheService = cacheService;
        _businessRules = businessRules;
    }

	public async Task<GetByIdCompanyResponse> Handle(GetByIdCompanyRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.CompanyIdShouldExistWhenSelected(request.Id);

		var cachedCompany = _cacheService.GetAll<GetByIdCompanyResponse>($"{CompaniesCacheKeys.GetById}{request.Id}");
		if (cachedCompany != null)
		{
			return cachedCompany;
		}

		Company company = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        GetByIdCompanyResponse response = _mapper.Map<GetByIdCompanyResponse>(company);

        _cacheService.Set($"{CompaniesCacheKeys.GetById}{request.Id}", response, TimeSpan.FromMinutes(1));

        return response;
    }
}