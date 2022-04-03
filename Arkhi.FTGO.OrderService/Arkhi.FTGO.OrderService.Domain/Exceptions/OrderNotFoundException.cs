using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.OrderService.Domain.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException()
            : base("Could not find an order with the given id")
        {
        }
    }
}