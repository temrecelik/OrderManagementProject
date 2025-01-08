namespace Application.Features.Products.Commands.Create
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
