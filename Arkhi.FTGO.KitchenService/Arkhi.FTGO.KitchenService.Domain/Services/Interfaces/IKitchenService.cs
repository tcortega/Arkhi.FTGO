using Arkhi.FTGO.KitchenService.Domain.Entities;

namespace Arkhi.FTGO.KitchenService.Domain.Services.Interfaces
{
    public interface IKitchenService
    {
        KitchenOrder Validate(int id);
        KitchenOrder FinishOrder(int id);
        KitchenOrder CancelOrder(int id);
        void HandleNewOrder(KitchenOrder entity);
    }
}