using Application.Repositories.OrderRepository;
using Application.Repositories.ProductCategoryRepository;
using Application.Repositories.ProductRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductCategories.Queries.GetAll;

public class GetAllProductCategoryHandler : IRequestHandler<GetAllProductCategoryRequest, List<GetAllProductCategoryResponse>>
{
   
    private readonly IMapper _mapper;
    private readonly IProductCategoryUnitOfWork _unitOfWork;

	public GetAllProductCategoryHandler(IMapper mapper, IProductCategoryUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public Task<List<GetAllProductCategoryResponse>> Handle(GetAllProductCategoryRequest request, CancellationToken cancellationToken)
    {

        List<ProductCategory> products = _unitOfWork.ReadRepository.GetAll().ToList();

        List<GetAllProductCategoryResponse> response = _mapper.Map<List<GetAllProductCategoryResponse>>(products);

        return Task.FromResult(response);
    }
}