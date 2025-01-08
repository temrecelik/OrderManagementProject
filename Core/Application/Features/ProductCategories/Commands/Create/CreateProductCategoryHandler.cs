
using Application.Features.ProductCategories.Rules;
using Application.Repositories.ProductCategoryRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryRequest, CreateProductCategoryResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductCategoryUnitOfWork _unitOfWork;
	private readonly IProductCategoryBusinessRules _businessRules;

	public CreateProductCategoryHandler(IMapper mapper, IProductCategoryUnitOfWork unitOfWork, IProductCategoryBusinessRules businessRules)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
	}

	public async Task<CreateProductCategoryResponse> Handle(CreateProductCategoryRequest request, CancellationToken cancellationToken)
    {
		await _businessRules.ProductCategoryNameCanNotBeDubplicated(request.Name);

        ProductCategory productCategory = _mapper.Map<ProductCategory>(request);

        await _unitOfWork.WriteRepository.AddAsync(productCategory);

		await _unitOfWork.SaveAsync();

		CreateProductCategoryResponse response = _mapper.Map<CreateProductCategoryResponse>(productCategory);
        return  response;
    }
}