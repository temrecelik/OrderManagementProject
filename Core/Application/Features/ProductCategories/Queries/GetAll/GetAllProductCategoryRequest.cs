using MediatR;

namespace Application.Features.ProductCategories.Queries.GetAll;

public class GetAllProductCategoryRequest : IRequest<List<GetAllProductCategoryResponse>>
{

}