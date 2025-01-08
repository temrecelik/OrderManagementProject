using Application.Features.Companies.Queries.GetById;
using Application.Repositories.CompanyRepository;
using Application.Repositories.ProductCategoryRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductCategories.Queries.GetById;

public class GetByIdProductCategoryHandler : IRequestHandler<GetByIdProductCategoryRequest, GetByIdProductCategoryResponse>
{
 
    private readonly IMapper _mapper;
    private readonly IProductCategoryUnitOfWork _unitOfWork;

	public GetByIdProductCategoryHandler(IMapper mapper, IProductCategoryUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<GetByIdProductCategoryResponse> Handle(GetByIdProductCategoryRequest request, CancellationToken cancellationToken)
    {
		ProductCategory productCategory = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        GetByIdProductCategoryResponse response = _mapper.Map<GetByIdProductCategoryResponse>(productCategory);

        return response;
    }
}