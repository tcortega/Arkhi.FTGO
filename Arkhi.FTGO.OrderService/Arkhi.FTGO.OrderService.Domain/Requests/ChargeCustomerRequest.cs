namespace Arkhi.FTGO.OrderService.Domain.Requests
{
    public class ChargeCustomerRequest
    {
        public int CustomerId { get; set; }
        public decimal OrderPrice { get; set; }

        public static ChargeCustomerRequest Create(int customerId, decimal orderPrice)
        {
            return new() {CustomerId = customerId, OrderPrice = orderPrice};
        }
    }
}