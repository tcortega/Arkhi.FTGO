namespace Arkhi.FTGO.OrderService.Domain.Commands
{
    public class CreateNewOrderItemCommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}