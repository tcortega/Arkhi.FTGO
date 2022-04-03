using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.DeliveryService.Domain.Exceptions
{
    public class DeliveryOrderUpdateException : BusinessLogicException
    {
        public DeliveryOrderUpdateException(string description)
            : base($"It is not possible update the order status. Reason: Order status currently is {description}.")
        {
        }
    }
}