namespace Arkhi.FTGO.KitchenService.Domain.Events
{
    public class OrderItemCreatedEvent
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}