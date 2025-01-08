using MediatR;

namespace Application.Features.Products.Queries.GetAll;

public class GetAllProductRequest : IRequest<List<GetAllProductResponse>>
{

}