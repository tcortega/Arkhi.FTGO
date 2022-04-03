using Arkhi.FTGO.Libs.Infra;
using Arkhi.FTGO.OrderService.Domain.Entities;
using Arkhi.FTGO.OrderService.Domain.Repositories;
using Arkhi.FTGO.OrderService.Infra.Data;

namespace Arkhi.FTGO.OrderService.Infra.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}