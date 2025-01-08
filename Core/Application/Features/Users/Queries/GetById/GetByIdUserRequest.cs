using MediatR;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserRequest : IRequest<GetByIdUserResponse>
{
    public GetByIdUserRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }

}