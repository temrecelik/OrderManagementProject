using Application.Repositories.ProductCategoryRepository;
using Microsoft.EntityFrameworkCore;
using Application.Excepetions;

namespace Application.Features.ProductCategories.Rules
{
	public class ProductCategoryBusinessRules : IProductCategoryBusinessRules
	{
		private readonly IProductCategoryUnitOfWork _unitOfWork;

		public ProductCategoryBusinessRules(IProductCategoryUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public async Task ProductCategoryNameCanNotBeDubplicated(string name)
		{
		  var ProductCategoryName = await _unitOfWork.ReadRepository.GetAll().FirstOrDefaultAsync(b  => b.Name == name);
		  if (ProductCategoryName != null) throw new BusinessException("Product Category exist");
		}



	}
}
