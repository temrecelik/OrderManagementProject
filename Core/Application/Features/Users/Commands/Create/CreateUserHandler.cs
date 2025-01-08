using Application.Features.Users.Rules;
using Application.Repositories.UserRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Create;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IUserBusinessRules _businessRules;

	public CreateUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork, IUserBusinessRules businessRules)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_businessRules = businessRules;
	}

	public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.EmailAdressCannotBeExist(request.Email);

        User mappedUser = _mapper.Map<User>(request);

        await _unitOfWork.WriteRepository.AddAsync(mappedUser);

		await _unitOfWork.SaveAsync();

		CreateUserResponse response = _mapper.Map<CreateUserResponse>(mappedUser);

        return response;
    }
}