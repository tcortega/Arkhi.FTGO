using System.Collections.Generic;

namespace Arkhi.FTGO.OrderService.Domain.Events
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemCreatedEvent> Items { get; set; }
        public decimal Total { get; set; }
    }
}