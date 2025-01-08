using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetAll;
using Application.Features.Companies.Queries.GetById;
using Application.Repositories.CompanyRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : BaseController<
    CreateCompanyRequest,
    UpdateCompanyRequest,
    DeleteCompanyRequest,
    GetByIdCompanyRequest,
    GetAllCompanyRequest,
    DeleteCompanyResponse,
    GetByIdCompanyResponse
>
{
    private readonly ICompanyUnitOfWork _unitOfWork;

    public CompanyController(IMediator mediator, ICompanyUnitOfWork unitOfWork, ILogger<CompanyController> logger) : base(logger, mediator)
    {
        _unitOfWork = unitOfWork;
    }
}