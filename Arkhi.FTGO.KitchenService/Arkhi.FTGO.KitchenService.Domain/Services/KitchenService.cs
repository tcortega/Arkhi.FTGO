using Arkhi.FTGO.KitchenService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Domain.Entities.Enums;
using Arkhi.FTGO.KitchenService.Domain.Exceptions;
using Arkhi.FTGO.KitchenService.Domain.Repositories;
using Arkhi.FTGO.KitchenService.Domain.Services.Interfaces;
using Arkhi.FTGO.Libs.Common.Enums;
using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.KitchenService.Domain.Services
{
    public class KitchenService : IKitchenService
    {
        private readonly IKitchenOrderItemRepository _orderItemRepository;
        private readonly IKitchenRepository _repository;

        public KitchenService(IKitchenRepository repository, IKitchenOrderItemRepository orderItemRepository)
        {
            _repository = repository;
            _orderItemRepository = orderItemRepository;
        }

        public KitchenOrder Validate(int id)
        {
            var kitchenOrder = _repository.Find(id);

            if (kitchenOrder is null) throw new KitchenOrderNotFoundException();

            return kitchenOrder;
        }

        public KitchenOrder FinishOrder(int id)
        {
            var kitchenOrder = Validate(id);

            ValidateUpdatingOrder(kitchenOrder);

            kitchenOrder.Status = KitchenOrderStatus.Finished;
            _repository.Update(kitchenOrder);

            return kitchenOrder;
        }

        public KitchenOrder CancelOrder(int id)
        {
            var kitchenOrder = Validate(id);

            ValidateUpdatingOrder(kitchenOrder);

            kitchenOrder.Status = KitchenOrderStatus.Cancelled;
            _repository.Update(kitchenOrder);

            return kitchenOrder;
        }

        public void HandleNewOrder(KitchenOrder entity)
        {
            _repository.Add(entity);
            _orderItemRepository.Add(entity.Items);
            _repository.Commit();
        }

        private static void ValidateUpdatingOrder(KitchenOrder order)
        {
            if (order.Status == KitchenOrderStatus.Preparing) return;

            throw new BusinessLogicException(
                $"It is not possible update this order. Reason: Order status is {order.Status.GetDescription(true)}.");
        }
    }
}