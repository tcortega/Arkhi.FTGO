using System;
using System.Collections.Generic;
using Arkhi.FTGO.Libs.Common.Enums;

namespace Arkhi.FTGO.OrderHistoryService.Application.Dtos.Responses
{
    public class OrderHistoryResponse
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemHistoryResponse> Items { get; set; }
        public decimal Total { get; set; }
        public string DeliveryAddress { get; set; }
        public EnumValue Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}