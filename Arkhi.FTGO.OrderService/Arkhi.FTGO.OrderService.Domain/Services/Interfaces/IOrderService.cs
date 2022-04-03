using System.Threading.Tasks;
using Arkhi.FTGO.OrderService.Domain.Commands;
using Arkhi.FTGO.OrderService.Domain.Entities;

namespace Arkhi.FTGO.OrderService.Domain.Services.Interfaces
{
    public interface IOrderService
    {
        Order Validate(int id);
        Task<Order> Add(CreateNewOrderCommand command);

        Task HandleOrderCancelledEvent(int orderId);
        // void HandleOrderUpdatedEvent(int orderId, OrderStatus newStatus);
    }
}