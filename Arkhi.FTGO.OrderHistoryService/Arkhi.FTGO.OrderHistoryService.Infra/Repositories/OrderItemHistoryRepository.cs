using Arkhi.FTGO.Libs.Infra;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Arkhi.FTGO.OrderHistoryService.Domain.Repositories;
using Arkhi.FTGO.OrderHistoryService.Infra.Data;

namespace Arkhi.FTGO.OrderHistoryService.Infra.Repositories
{
    public class OrderItemHistoryRepository : RepositoryBase<OrderItemHistory>, IOrderItemHistoryRepository
    {
        public OrderItemHistoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}