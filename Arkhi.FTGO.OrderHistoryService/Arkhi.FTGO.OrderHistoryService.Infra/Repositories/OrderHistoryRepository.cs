using Arkhi.FTGO.Libs.Infra;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Arkhi.FTGO.OrderHistoryService.Domain.Repositories;
using Arkhi.FTGO.OrderHistoryService.Infra.Data;

namespace Arkhi.FTGO.OrderHistoryService.Infra.Repositories
{
    public class OrderHistoryRepository : RepositoryBase<OrderHistory>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}