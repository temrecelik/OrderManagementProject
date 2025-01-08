using Application.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;
using Application.Excepetions;

namespace Application.Features.Products.Rules
{
	public class ProductBusinessRules
	{
		private readonly IProductUnitOfWork _unitOfWork;
		

		public ProductBusinessRules(IProductUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task ProductNameCanNotBeDuplicated(string name)
		{
			var ProductName = await _unitOfWork.ReadRepository.GetAll().FirstOrDefaultAsync(b=>b.Name == name);
			if (ProductName != null) throw new BusinessException("Product name exist");
		}
	}
}
