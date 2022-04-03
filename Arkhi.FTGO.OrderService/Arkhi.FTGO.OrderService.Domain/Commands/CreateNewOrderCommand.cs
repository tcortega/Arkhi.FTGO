using System.Collections.Generic;

namespace Arkhi.FTGO.OrderService.Domain.Commands
{
    public class CreateNewOrderCommand
    {
        public int CustomerId { get; set; }
        public List<CreateNewOrderItemCommand> Items { get; set; }
    }
}