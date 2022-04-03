using Arkhi.FTGO.DeliveryService.Domain.Events;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities;

namespace Arkhi.FTGO.OrderHistoryService.Domain.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        void HandleOrderCancelledEvent(int orderId);
        void HandleOrderCompletedEvent(int orderId);
        void HandleNewOrder(OrderHistory entity);
        void HandleDeliveryStartedEvent(DeliveryStartedEvent contextMessage);
        void HandleKitchenFinishedEvent(KitchenFinishedEvent contextMessage);
    }
}