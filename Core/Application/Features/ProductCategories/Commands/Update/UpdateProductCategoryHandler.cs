using Application.Features.ProductCategories.Rules;
using Application.Repositories.ProductCategoryRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductCategories.Commands.Update;

public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryRequest, UpdateProductCategoryResponse>
{
  
    private readonly IMapper _mapper;
    private readonly IProductCategoryUnitOfWork _unitOfWork;
    private readonly ProductCategoryBusinessRules _businessRules;

	public UpdateProductCategoryHandler(IMapper mapper, IProductCategoryUnitOfWork unitOfWork, ProductCategoryBusinessRules businessRules)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
	}

	public async Task<UpdateProductCategoryResponse> Handle(UpdateProductCategoryRequest request, CancellationToken cancellationToken)
    {
		await _businessRules.ProductCategoryNameCanNotBeDubplicated(request.Name);

        ProductCategory productCategory = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        productCategory = _mapper.Map(request, productCategory);

        await _unitOfWork.WriteRepository.Update(productCategory);

		await _unitOfWork.SaveAsync();

		UpdateProductCategoryResponse response = _mapper.Map<UpdateProductCategoryResponse>(productCategory);

        return response;
    }
}