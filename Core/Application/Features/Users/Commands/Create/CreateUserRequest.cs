using MediatR;

namespace Application.Features.Users.Commands.Create;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    //password eklenecek
}