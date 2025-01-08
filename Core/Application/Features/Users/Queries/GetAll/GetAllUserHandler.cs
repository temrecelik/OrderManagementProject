using Application.Repositories.UserRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetAll;

public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
{
    
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _unitOfWork;

	public GetAllUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
   
        List<User> user = _unitOfWork.ReadRepository.GetAll().ToList();

        List<GetAllUserResponse> response = _mapper.Map<List<GetAllUserResponse>>(user);

        return Task.FromResult(response);
    }
}