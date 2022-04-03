using System.Collections.Generic;
using Arkhi.FTGO.OrderHistoryService.Application.Dtos.Responses;

namespace Arkhi.FTGO.OrderHistoryService.Application.Services.Interfaces
{
    public interface IOrderHistoryAppService
    {
        OrderHistoryResponse GetById(int id);
        OrderHistoryResponse GetByOrderId(int orderId);
        IEnumerable<OrderHistoryResponse> GetByCustomerId(int customerId);
    }
}