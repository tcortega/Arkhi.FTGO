using Arkhi.FTGO.DeliveryService.Domain.Entities;
using Arkhi.FTGO.DeliveryService.Domain.Repositories;
using Arkhi.FTGO.DeliveryService.Infra.Data;
using Arkhi.FTGO.Libs.Infra;

namespace Arkhi.FTGO.DeliveryService.Infra.Repositories
{
    public class KitchenRepository : RepositoryBase<DeliveryOrder>, IKitchenRepository
    {
        public KitchenRepository(AppDbContext context) : base(context)
        {
        }
    }
}