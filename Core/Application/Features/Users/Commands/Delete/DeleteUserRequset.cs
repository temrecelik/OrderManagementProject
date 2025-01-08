using MediatR;

namespace Application.Features.Users.Commands.Delete;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public DeleteUserRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}