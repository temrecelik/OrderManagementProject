using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetById;
using Application.Repositories.CompanyRepository;
using Application.Repositories.ProductCategoryRepository;
using Application.Repositories.ProductRepository;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : BaseController<
    CreateProductRequest,
    UpdateProductRequest,
    DeleteProductRequest,
    GetByIdProductRequest,
    GetAllProductRequest,
    DeleteProductResponse,
    GetByIdProductResponse
>
{
    private readonly IProductUnitOfWork _unitOfWork;
    private readonly ICompanyUnitOfWork _companyUnitOfWork;
    private readonly IProductCategoryUnitOfWork _productCategoryUnitOfWork;

    public ProductController(
        IMediator mediator,
        IProductUnitOfWork unitOfWork,
        ICompanyUnitOfWork companyUnitOfWork,
        IProductCategoryUnitOfWork productCategoryUnitOfWork,
        IMapper mapper,
        ILogger<ProductController> logger) : base(logger, mediator)
    {
        _unitOfWork = unitOfWork;
        _companyUnitOfWork = companyUnitOfWork;
        _productCategoryUnitOfWork = productCategoryUnitOfWork;
       
    }
}