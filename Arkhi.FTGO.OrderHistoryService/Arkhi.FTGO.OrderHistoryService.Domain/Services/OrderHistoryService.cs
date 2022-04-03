using System;
using Arkhi.FTGO.DeliveryService.Domain.Events;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities.Enums;
using Arkhi.FTGO.OrderHistoryService.Domain.Exceptions;
using Arkhi.FTGO.OrderHistoryService.Domain.Repositories;
using Arkhi.FTGO.OrderHistoryService.Domain.Services.Interfaces;

namespace Arkhi.FTGO.OrderHistoryService.Domain.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IOrderItemHistoryRepository _orderItemHistoryRepository;
        private readonly IOrderHistoryRepository _repository;

        public OrderHistoryService(IOrderHistoryRepository repository, IOrderItemHistoryRepository orderItemHistoryRepository)
        {
            _repository = repository;
            _orderItemHistoryRepository = orderItemHistoryRepository;
        }

        public void HandleOrderCancelledEvent(int orderId)
        {
            var order = Validate(orderId);

            order.Status = OrderHistoryStatus.Cancelled;
            UpdateAndCommitOrder(order);
        }

        public void HandleOrderCompletedEvent(int orderId)
        {
            var order = Validate(orderId);

            order.Status = OrderHistoryStatus.Completed;
            order.DeliveredAt = DateTime.Now;
            UpdateAndCommitOrder(order);
        }

        public void HandleNewOrder(OrderHistory entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.Status = OrderHistoryStatus.Preparing;
            _repository.Add(entity);
            _orderItemHistoryRepository.Add(entity.Items);
            _repository.Commit();
        }

        public void HandleDeliveryStartedEvent(DeliveryStartedEvent contextMessage)
        {
            var order = Validate(contextMessage.OrderId);

            order.Status = OrderHistoryStatus.Delivering;
            order.DeliveryAddress = contextMessage.DeliveryAddress;
            UpdateAndCommitOrder(order);
        }

        public void HandleKitchenFinishedEvent(KitchenFinishedEvent contextMessage)
        {
            var order = Validate(contextMessage.OrderId);

            order.Status = OrderHistoryStatus.AwaitingPickup;
            UpdateAndCommitOrder(order);
        }

        private OrderHistory Validate(int id)
        {
            var orderHistory = _repository.Find(id);

            if (orderHistory is null) throw new OrderHistoryNotFoundException();

            return orderHistory;
        }

        private void UpdateAndCommitOrder(OrderHistory order)
        {
            _repository.Update(order);
            _repository.Commit();
        }
    }
}