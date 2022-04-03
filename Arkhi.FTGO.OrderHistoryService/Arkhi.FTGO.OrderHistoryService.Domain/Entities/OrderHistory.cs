using System;
using System.Collections.Generic;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities.Enums;

namespace Arkhi.FTGO.OrderHistoryService.Domain.Entities
{
    public class OrderHistory : EntityBase
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderItemHistory> Items { get; set; } = new List<OrderItemHistory>();
        public decimal Total { get; set; }
        public string? DeliveryAddress { get; set; }
        public OrderHistoryStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}