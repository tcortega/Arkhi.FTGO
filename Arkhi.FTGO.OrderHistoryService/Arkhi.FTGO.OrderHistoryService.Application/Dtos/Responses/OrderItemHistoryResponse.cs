namespace Arkhi.FTGO.OrderHistoryService.Application.Dtos.Responses
{
    public class OrderItemHistoryResponse
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}