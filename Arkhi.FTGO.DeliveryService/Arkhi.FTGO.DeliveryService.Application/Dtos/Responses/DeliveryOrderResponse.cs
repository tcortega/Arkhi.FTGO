using Arkhi.FTGO.Libs.Common.Enums;

namespace Arkhi.FTGO.DeliveryService.Application.Dtos.Responses
{
    public class DeliveryOrderResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public EnumValue Status { get; set; }
    }
}