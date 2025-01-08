using Application.Features.Companies.Queries.GetById;
using Application.Repositories.CompanyRepository;
using Application.Repositories.UserRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserHandler : IRequestHandler<GetByIdUserRequest, GetByIdUserResponse>
{
  
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _unitOfWork;

	public GetByIdUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<GetByIdUserResponse> Handle(GetByIdUserRequest request, CancellationToken cancellationToken)
    {
        User user = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);

        return response;
    }
}