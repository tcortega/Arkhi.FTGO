namespace Arkhi.FTGO.KitchenService.Domain.Entities
{
    public class KitchenOrderItem : EntityBase
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}