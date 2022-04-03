using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.CustomerService.Domain.Exceptions
{
    public class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException()
            : base("Could not find customer with the given id")
        {
        }
    }
}