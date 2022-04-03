using System.Collections.Generic;
using Arkhi.FTGO.KitchenService.Domain.Events;

namespace Arkhi.FTGO.OrderService.Domain.Events
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemCreatedEvent> Items { get; set; }
    }
}