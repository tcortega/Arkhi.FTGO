namespace Arkhi.FTGO.OrderService.Application.Dtos.Responses
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}