using Application.Features.Companies.Queries.GetById;
using Application.Features.Products.Queries.GetAll;
using Application.Repositories.ProductRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, GetByIdProductResponse>
{

    private readonly IMapper _mapper;
    private readonly IProductUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;

	public GetByIdProductHandler(IMapper mapper, IProductUnitOfWork unitOfWork, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_cacheService = cacheService;
	}

	public async Task<GetByIdProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
    {
		var cacheKey = $"GetProductById_{request.Id}";
		var cachedProduct = _cacheService.GetAll<GetByIdProductResponse>(cacheKey);
		if (cachedProduct != null)
		{
			return cachedProduct;
		}

		Product product = _mapper.Map<Product>(request);

        await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        GetByIdProductResponse response = _mapper.Map<GetByIdProductResponse>(product);

		_cacheService.Set(cacheKey, response, TimeSpan.FromHours(1));

		return response;
    }
}