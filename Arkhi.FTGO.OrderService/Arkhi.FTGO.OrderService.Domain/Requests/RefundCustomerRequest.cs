using System.Text.Json.Serialization;

namespace Arkhi.FTGO.OrderService.Domain.Requests
{
    public class RefundCustomerRequest
    {
        [JsonPropertyName("id")] public int CustomerId { get; set; }

        [JsonPropertyName("balance")] public decimal TotalPrice { get; set; }

        public static RefundCustomerRequest Create(int customerId, decimal totalPrice)
        {
            return new() {CustomerId = customerId, TotalPrice = totalPrice};
        }
    }
}