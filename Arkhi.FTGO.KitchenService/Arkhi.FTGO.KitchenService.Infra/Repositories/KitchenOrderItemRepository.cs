using Arkhi.FTGO.KitchenService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Domain.Repositories;
using Arkhi.FTGO.KitchenService.Infra.Data;
using Arkhi.FTGO.Libs.Infra;

namespace Arkhi.FTGO.KitchenService.Infra.Repositories
{
    public class KitchenOrderItemRepository : RepositoryBase<KitchenOrderItem>, IKitchenOrderItemRepository
    {
        public KitchenOrderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}