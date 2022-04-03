using Arkhi.FTGO.Libs.Infra;
using Arkhi.FTGO.OrderService.Domain.Entities;
using Arkhi.FTGO.OrderService.Domain.Repositories;
using Arkhi.FTGO.OrderService.Infra.Data;

namespace Arkhi.FTGO.OrderService.Infra.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}