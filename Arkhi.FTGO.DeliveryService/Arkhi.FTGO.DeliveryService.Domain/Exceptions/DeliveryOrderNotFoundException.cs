using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.DeliveryService.Domain.Exceptions
{
    public class DeliveryOrderNotFoundException : NotFoundException
    {
        public DeliveryOrderNotFoundException()
            : base("Could not find an order with the given id")
        {
        }
    }
}