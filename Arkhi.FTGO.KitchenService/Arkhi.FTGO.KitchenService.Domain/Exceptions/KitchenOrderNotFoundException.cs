using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.KitchenService.Domain.Exceptions
{
    public class KitchenOrderNotFoundException : NotFoundException
    {
        public KitchenOrderNotFoundException()
            : base("Could not find an order with the given id")
        {
        }
    }
}