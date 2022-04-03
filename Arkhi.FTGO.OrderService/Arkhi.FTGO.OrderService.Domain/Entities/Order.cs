using System.Collections.Generic;

namespace Arkhi.FTGO.OrderService.Domain.Entities
{
    public class Order : EntityBase
    {
        public int CustomerId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public decimal Total { get; set; }
    }
}