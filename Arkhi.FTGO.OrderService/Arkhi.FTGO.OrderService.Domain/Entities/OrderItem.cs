namespace Arkhi.FTGO.OrderService.Domain.Entities
{
    public class OrderItem : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}