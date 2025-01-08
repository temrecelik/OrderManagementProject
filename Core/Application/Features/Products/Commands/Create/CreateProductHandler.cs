using Application.Features.Products.Rules;
using Application.Repositories.ProductRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        
        private readonly IMapper _mapper;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly ProductBusinessRules _businessRules;
        private readonly ICacheService _cacheService;

		public CreateProductHandler(IMapper mapper, IProductUnitOfWork unitOfWork, ProductBusinessRules businessRules, ICacheService cacheService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_businessRules = businessRules;
			_cacheService = cacheService;
		}

		public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            await _businessRules.ProductNameCanNotBeDuplicated(request.Name);

            Product product = _mapper.Map<Product>(request);

            await _unitOfWork.WriteRepository.AddAsync(product);

			await _unitOfWork.SaveAsync();

			List<Product> productsInCache = _cacheService.GetAll<List<Product>>("AllProducts");
			productsInCache.Add(product);

			_cacheService.Set("AllProducts", productsInCache, TimeSpan.FromHours(3));

			_cacheService.Remove("All Of Them");

			CreateProductResponse response = _mapper.Map<CreateProductResponse>(product);

            return response;
        }
    }
}
