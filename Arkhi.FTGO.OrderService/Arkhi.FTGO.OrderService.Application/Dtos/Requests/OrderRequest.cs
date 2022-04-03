using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Arkhi.FTGO.Libs.Core.DataAnnotations;

namespace Arkhi.FTGO.OrderService.Application.Dtos.Requests
{
    public class OrderRequest
    {
        [Min(1)] [Required] public int CustomerId { get; set; }

        [MinLength(1)] [Required] public List<OrderItemRequest> Items { get; set; }
    }
}