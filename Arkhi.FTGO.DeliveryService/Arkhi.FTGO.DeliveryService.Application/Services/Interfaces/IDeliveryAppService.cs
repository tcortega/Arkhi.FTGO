using System.Collections.Generic;
using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Application.Dtos.Responses;

namespace Arkhi.FTGO.DeliveryService.Application.Services.Interfaces
{
    public interface IDeliveryAppService
    {
        DeliveryOrderResponse Get(int id);
        IEnumerable<DeliveryOrderResponse> Get();
        Task StartDelivery(int id);
        Task FinishDelivery(int id);
    }
}