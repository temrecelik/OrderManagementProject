using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Commands.Delete;
using Application.Features.ProductCategories.Commands.Update;
using Application.Features.ProductCategories.Queries.GetAll;
using Application.Features.ProductCategories.Queries.GetById;
using Application.Repositories.ProductCategoryRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : BaseController<
        CreateProductCategoryRequest,
        UpdateProductCategoryRequest,
        DeleteProductCategoryRequest,
        GetByIdProductCategoryRequest,
        GetAllProductCategoryRequest,
        DeleteProductCategoryResponse,
        GetByIdProductCategoryResponse
    >
    {
        private readonly IProductCategoryUnitOfWork _unitOfWork;

        public ProductCategoryController(IMediator mediator, IProductCategoryUnitOfWork unitOfWork, ILogger<ProductCategoryController> logger) : base(logger, mediator)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
