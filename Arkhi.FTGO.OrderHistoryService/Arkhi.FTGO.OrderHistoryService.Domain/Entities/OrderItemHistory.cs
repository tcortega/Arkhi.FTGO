namespace Arkhi.FTGO.OrderHistoryService.Domain.Entities
{
    public class OrderItemHistory : EntityBase
    {
        public int OrderItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}