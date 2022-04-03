using System.Threading.Tasks;
using Arkhi.FTGO.OrderService.Application.Dtos.Requests;
using Arkhi.FTGO.OrderService.Application.Dtos.Responses;

namespace Arkhi.FTGO.OrderService.Application.Services.Interfaces
{
    public interface IOrderAppService
    {
        OrderResponse GetById(int id);
        Task<OrderResponse> Add(OrderRequest request);
    }
}