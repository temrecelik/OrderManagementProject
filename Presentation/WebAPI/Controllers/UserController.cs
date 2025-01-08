using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using Application.Repositories.UserRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController<
    CreateUserRequest,
    UpdateUserRequest,
    DeleteUserRequest,
    GetByIdUserRequest,
    GetAllUserRequest,
    DeleteUserResponse,
    GetByIdUserResponse
>
{
  

    private readonly IUserUnitOfWork _unitOfWork;

    public UserController(
        IMediator mediator,
        IUserUnitOfWork unitOfWork,
        ILogger<UserController> logger) : base(logger, mediator)
    {
        _unitOfWork = unitOfWork;
    }
}