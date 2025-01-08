using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<
    TCreateRequest, TUpdateRequest, TDeleteRequest, TGetByIdRequest, TGetAllRequest, TDeleteResponse, TGetByIdResponse> : ControllerBase
    where TDeleteRequest : IRequest<TDeleteResponse>
    where TGetByIdRequest : IRequest<TGetByIdResponse>
{
    protected readonly IMediator Mediator;
    protected readonly ILogger<BaseController<TCreateRequest, TUpdateRequest, TDeleteRequest, TGetByIdRequest, TGetAllRequest, TDeleteResponse, TGetByIdResponse>> Logger;

    protected BaseController(ILogger<BaseController<TCreateRequest, TUpdateRequest, TDeleteRequest, TGetByIdRequest, TGetAllRequest, TDeleteResponse, TGetByIdResponse>> logger, IMediator mediator)
    {
        Mediator = mediator;
        Logger = logger;
    }

    [HttpPost]
    public virtual async Task<IActionResult> Add([FromBody] TCreateRequest createCommand)
    {
        Logger.LogInformation("Add method called with request: {Request}", createCommand);
        var response = await Mediator.Send(createCommand!);
        return Created(uri: "", response);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Update([FromBody] TUpdateRequest updateCommand)
    {
        Logger.LogInformation("Update method called with request: {Request}", updateCommand);
        var response = await Mediator.Send(updateCommand!);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        Logger.LogInformation("Delete method called with id: {Id}", id);
        var command = (TDeleteRequest)Activator.CreateInstance(typeof(TDeleteRequest), id)!;
        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Logger.LogInformation("GetById method called with id: {Id}", id);
        var request = (TGetByIdRequest)Activator.CreateInstance(typeof(TGetByIdRequest), id)!;
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        Logger.LogInformation("GetAll method called");
        var query = (TGetAllRequest)Activator.CreateInstance(typeof(TGetAllRequest))!;
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}
