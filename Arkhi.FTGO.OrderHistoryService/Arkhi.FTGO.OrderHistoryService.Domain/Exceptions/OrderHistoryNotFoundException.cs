using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.OrderHistoryService.Domain.Exceptions
{
    public class OrderHistoryNotFoundException : NotFoundException
    {
        public OrderHistoryNotFoundException()
            : base("Could not find an order history with the given id")
        {
        }
    }
}