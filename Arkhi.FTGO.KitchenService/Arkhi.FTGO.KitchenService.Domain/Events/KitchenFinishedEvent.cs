namespace Arkhi.FTGO.KitchenService.Domain.Events
{
    public class KitchenFinishedEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
    }
}