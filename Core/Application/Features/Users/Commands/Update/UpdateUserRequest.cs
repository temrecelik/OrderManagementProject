using MediatR;

namespace Application.Features.Users.Commands.Update;

public class UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
}