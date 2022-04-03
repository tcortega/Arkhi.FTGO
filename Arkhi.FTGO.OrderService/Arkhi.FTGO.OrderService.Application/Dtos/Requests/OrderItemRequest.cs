using System.ComponentModel.DataAnnotations;
using Arkhi.FTGO.Libs.Core.DataAnnotations;

namespace Arkhi.FTGO.OrderService.Application.Dtos.Requests
{
    public class OrderItemRequest
    {
        [MinLength(3)] [Required] public string Name { get; set; }

        [Required] [Min(0.01)] public decimal Price { get; set; }

        [Min(1)] [Required] public int Quantity { get; set; }
    }
}