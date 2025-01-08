using Application.Features.Products.Rules;
using Application.Repositories;
using Application.Repositories.ProductRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
   
    private readonly IMapper _mapper;
    private readonly IProductUnitOfWork _unitOfWork;
    private readonly ProductBusinessRules _businessRules;
    private readonly ICacheService _cacheService;

	public UpdateProductHandler(IMapper mapper, IProductUnitOfWork unitOfWork, ProductBusinessRules businessRules, ICacheService cacheService)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
		_cacheService = cacheService;
	}

	public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.ProductNameCanNotBeDuplicated(request.Name);

        Product product = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        product = _mapper.Map(request, product);

        await _unitOfWork.WriteRepository.Update(product);

		await _unitOfWork.SaveAsync();

		List<Product> productsInCache = _cacheService.GetAll<List<Product>>("AllProducts") ?? new List<Product>();

		productsInCache.RemoveAll(p => p.Id == request.Id);

		productsInCache.Add(product);

		_cacheService.Set("AllProducts", productsInCache, TimeSpan.FromHours(3));

		UpdateProductResponse response = _mapper.Map<UpdateProductResponse>(product);

        return response;

    }
}