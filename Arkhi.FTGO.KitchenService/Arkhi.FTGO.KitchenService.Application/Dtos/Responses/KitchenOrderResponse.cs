using System.Collections.Generic;
using Arkhi.FTGO.Libs.Common.Enums;

namespace Arkhi.FTGO.KitchenService.Application.Dtos.Responses
{
    public class KitchenOrderResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<KitchenOrderItemResponse> Items { get; set; }
        public EnumValue Status { get; set; }
    }
}