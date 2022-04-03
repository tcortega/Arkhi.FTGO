using System.Collections.Generic;
using System.Threading.Tasks;
using Arkhi.FTGO.KitchenService.Application.Dtos.Responses;

namespace Arkhi.FTGO.KitchenService.Application.Services.Interfaces
{
    public interface IKitchenAppService
    {
        KitchenOrderResponse Get(int id);
        IEnumerable<KitchenOrderResponse> Get();
        Task FinishOrder(int id);
        Task CancelOrder(int id);
    }
}