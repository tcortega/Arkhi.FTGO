using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Domain.Events;

namespace Arkhi.FTGO.DeliveryService.Domain.Services.Interfaces
{
    public interface IDeliveryService
    {
        DeliveryOrder Validate(int id);
        DeliveryOrder StartDelivery(int id);
        DeliveryOrder FinishDelivery(int id);
        Task HandleDelivery(KitchenFinishedEvent msg);
    }
}