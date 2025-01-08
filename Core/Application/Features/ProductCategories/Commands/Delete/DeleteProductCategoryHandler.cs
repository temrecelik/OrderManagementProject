using Application.Repositories;
using Application.Repositories.ProductCategoryRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductCategories.Commands.Delete;

public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryRequest, DeleteProductCategoryResponse>
{
    
  
    private readonly IProductCategoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

	public DeleteProductCategoryHandler(IProductCategoryUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<DeleteProductCategoryResponse> Handle(DeleteProductCategoryRequest request, CancellationToken cancellationToken)
    {
     
        ProductCategory productCategory = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        await _unitOfWork.WriteRepository.RemoveAsync(request.Id);

		await _unitOfWork.SaveAsync();

		DeleteProductCategoryResponse response = _mapper.Map<DeleteProductCategoryResponse>(productCategory);

        return response;
    }
}