using System.Collections.Generic;
using Arkhi.FTGO.KitchenService.Domain.Entities.Enums;

namespace Arkhi.FTGO.KitchenService.Domain.Entities
{
    public class KitchenOrder : EntityBase
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public ICollection<KitchenOrderItem> Items { get; set; }
        public KitchenOrderStatus Status { get; set; }
    }
}