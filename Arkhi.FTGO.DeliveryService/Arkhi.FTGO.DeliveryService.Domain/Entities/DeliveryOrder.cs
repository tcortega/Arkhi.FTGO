using Arkhi.FTGO.DeliveryService.Domain.Entities.Enums;

namespace Arkhi.FTGO.DeliveryService.Domain.Entities
{
    public class DeliveryOrder : EntityBase
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public DeliveryOrderStatus Status { get; set; }
    }
}