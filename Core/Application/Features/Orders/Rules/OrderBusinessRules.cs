using Application.Repositories.OrderRepository;
using Application.Excepetions;

namespace Application.Features.Orders.Rules
{
	public class OrderBusinessRules
	{
		private readonly IOrderUnitOfWork _unitOfWork;
		


		public OrderBusinessRules(IOrderUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task UserRegisteredWhenOrdered(Guid id)
		{
			var user = await _unitOfWork.ReadRepository.GetByIdAsync(id);
			if (user == null)	throw new BusinessException("Log in to order");
		}

		public async Task IsThereAnyProductOnOrder(int count)
		{

			if (count == 0)
			{
				throw new BusinessException("There are no products in the order");
			}
		}



	}
}
