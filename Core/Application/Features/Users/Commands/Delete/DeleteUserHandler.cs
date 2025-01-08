using Application.Repositories.UserRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Delete;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
  
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _unitOfWork;

	public DeleteUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}


	public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
   
        User user = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        await _unitOfWork.WriteRepository.RemoveAsync(request.Id);

		await _unitOfWork.SaveAsync();

		DeleteUserResponse response = _mapper.Map<DeleteUserResponse>(user);

        return response;
    }
}