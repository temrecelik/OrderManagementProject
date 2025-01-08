using Application.Repositories.ProductRepository;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
 

        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

		public DeleteProductHandler(IProductUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_cacheService = cacheService;
		}

		public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {

            Product product = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            await _unitOfWork.WriteRepository.RemoveAsync(request.Id);

			await _unitOfWork.SaveAsync();

			List<Product> productsInCache = _cacheService.GetAll<List<Product>>("AllProducts") ?? new List<Product>();

			productsInCache.RemoveAll(p => p.Id == request.Id);

			_cacheService.Set("AllProducts", productsInCache, TimeSpan.FromHours(3));


			DeleteProductResponse response = _mapper.Map<DeleteProductResponse>(product);

            return response;
        }
    }
}
