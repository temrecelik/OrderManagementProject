using Application.Features.Companies.Queries.GetAll;
using Application.Features.ProductCategories.Queries.GetAll;
using Application.Repositories.ProductRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAll;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
{
   
    private readonly IMapper _mapper;
    private readonly IProductUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

	public GetAllProductHandler(IMapper mapper, IProductUnitOfWork unitOfWork, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_cacheService = cacheService;
	}

	public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
		var cacheKey = "GetAllProducts";
		var cachedProducts = _cacheService.GetAll<List<GetAllProductResponse>>(cacheKey);

		if (cachedProducts != null)
		{
			return cachedProducts;
		}


		var productRead = _unitOfWork.ReadRepository;

        List<Product> product = _unitOfWork.ReadRepository.GetAll().ToList();

        List<GetAllProductResponse> response = _mapper.Map<List<GetAllProductResponse>>(product);

		_cacheService.Set(cacheKey, response, TimeSpan.FromHours(1));

		return await Task.FromResult(response);
    }
}