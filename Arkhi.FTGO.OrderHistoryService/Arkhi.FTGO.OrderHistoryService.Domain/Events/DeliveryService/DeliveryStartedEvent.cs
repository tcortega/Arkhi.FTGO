namespace Arkhi.FTGO.DeliveryService.Domain.Events
{
    public class DeliveryStartedEvent
    {
        public int OrderId { get; set; }
        public string DeliveryAddress { get; set; }
    }
}