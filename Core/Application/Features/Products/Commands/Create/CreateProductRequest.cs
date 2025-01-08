using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ProductCategoryId { get; set; }



    }
}
