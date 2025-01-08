using Application.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Application.Excepetions;

namespace Application.Features.Users.Rules
{
	public class UserBusinessRules : IUserBusinessRules
	{
		private readonly IUserUnitOfWork _UnitOfWork;

		public UserBusinessRules(IUserUnitOfWork unitOfWork)
		{
			_UnitOfWork = unitOfWork;
		}

		public async Task EmailAdressCannotBeExist(string Email)
		{
			var UserMail = _UnitOfWork.ReadRepository.GetAll().FirstOrDefaultAsync(b=>b.Email == Email);
			if (UserMail != null) throw new BusinessException("EMail adress exist");
		}
	}
}
