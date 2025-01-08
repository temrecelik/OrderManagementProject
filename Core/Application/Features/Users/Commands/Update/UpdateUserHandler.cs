using Application.Features.Users.Rules;
using Application.Repositories.UserRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Update;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>

{
  
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly UserBusinessRules _businessRules;

	public UpdateUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork, UserBusinessRules businessRules)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
	}

	public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.EmailAdressCannotBeExist(request.Email);

        User user = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        user = _mapper.Map(request, user);

        await _unitOfWork.WriteRepository.Update(user);

		await _unitOfWork.SaveAsync();

		UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);

        return response;


    }
}