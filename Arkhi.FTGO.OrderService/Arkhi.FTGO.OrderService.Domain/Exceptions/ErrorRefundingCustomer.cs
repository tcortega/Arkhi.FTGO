using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.OrderService.Domain.Exceptions
{
    public class ErrorRefundingCustomer
        : BusinessLogicException
    {
        public ErrorRefundingCustomer() : base("It is not possible to cancel the order because the refund process failed.")
        {
        }
    }
}