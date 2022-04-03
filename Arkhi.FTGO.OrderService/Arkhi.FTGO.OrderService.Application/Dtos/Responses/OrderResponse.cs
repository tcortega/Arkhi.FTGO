using System.Collections.Generic;

namespace Arkhi.FTGO.OrderService.Application.Dtos.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public decimal Total { get; set; }
    }
}