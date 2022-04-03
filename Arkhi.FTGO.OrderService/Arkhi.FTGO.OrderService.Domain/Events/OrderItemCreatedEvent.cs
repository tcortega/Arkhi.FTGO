namespace Arkhi.FTGO.OrderService.Domain.Events
{
    public class OrderItemCreatedEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}