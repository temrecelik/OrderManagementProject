using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Queries.GetAll;
using Application.Features.Orders.Queries.GetById;
using Application.Repositories.CompanyRepository;
using Application.Repositories.OrderRepository;
using Application.Repositories.UserRepository;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderUnitOfWork _unitOfWork;
    private readonly ICompanyUnitOfWork _companyUnitOfWork;
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly IMediator _mediator;

	public OrderController(IOrderUnitOfWork unitOfWork, ICompanyUnitOfWork companyUnitOfWork, IUserUnitOfWork userUnitOfWork, IMediator mediator)
	{
		_unitOfWork = unitOfWork;
		_companyUnitOfWork = companyUnitOfWork;
		_userUnitOfWork = userUnitOfWork;
		_mediator = mediator;
	}
    [HttpPost]
	public async Task<IActionResult> Add([FromBody] CreateOrderRequest createCommand)
	{
		var response = await _mediator.Send(createCommand!);
		return Created(uri: "", response);
	}


	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] Guid id)
	{
		var request = (GetByIdOrderRequest)Activator.CreateInstance(typeof(GetByIdOrderRequest), id)!;
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var query = (GetAllOrderRequest)Activator.CreateInstance(typeof(GetAllOrderRequest))!;
		var response = await _mediator.Send(query);
		return Ok(response);
	}




	[HttpPost("SeedData")]
    public async Task<IActionResult> SeedData(int numberOfRecords)
    {
        Random random = new Random();

        List<Guid> companyIdList = new List<Guid>();
        foreach (var company in _companyUnitOfWork.ReadRepository.GetAll())
        {
            companyIdList.Add(company.Id);
        }

        List<Guid> userIdList = new List<Guid>();
        foreach (var user in _userUnitOfWork.ReadRepository.GetAll())
        {
            userIdList.Add(user.Id);
        }
        
        for (int i = 1; i <= numberOfRecords; i = i + 1)
        {
            var request = new CreateOrderRequest()
            {
                Name = $"Order Name {i}",
                UnitPrice = random.Next(10, 20),
                ProductCount = random.Next(1, 10),
                CompanyId = companyIdList[random.Next(0, companyIdList.Count)],
                UserId = userIdList[random.Next(0, userIdList.Count)]
            };

            Order order = new()
            {
                Name = request.Name,
                UnitPrice = request.UnitPrice,
                ProductCount = request.ProductCount,
                TotalPrice = request.UnitPrice * request.ProductCount,
                OrderStatus = OrderStatus.Pending,
                //Company = _companyUnitOfWork.ReadRepository.GetByIdAsync(request.CompanyId).Result,
                User = _userUnitOfWork.ReadRepository.GetByIdAsync(request.UserId).Result
            };

            await _unitOfWork.WriteRepository.AddAsync(order);
        }

        await _unitOfWork.SaveAsync();

        return Ok($"{numberOfRecords} Order have been created.");
    }
}