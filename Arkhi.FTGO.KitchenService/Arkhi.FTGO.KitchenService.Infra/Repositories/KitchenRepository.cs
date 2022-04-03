using Arkhi.FTGO.KitchenService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Domain.Repositories;
using Arkhi.FTGO.KitchenService.Infra.Data;
using Arkhi.FTGO.Libs.Infra;

namespace Arkhi.FTGO.KitchenService.Infra.Repositories
{
    public class KitchenRepository : RepositoryBase<KitchenOrder>, IKitchenRepository
    {
        public KitchenRepository(AppDbContext context) : base(context)
        {
        }
    }
}