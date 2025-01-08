namespace Application.Features.Orders.Commands.Create
{
    public class CreateOrderResponse
    {
        public string Name { get; set; }
        public int OrderCount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
