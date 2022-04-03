using System.ComponentModel.DataAnnotations;

namespace Arkhi.FTGO.OrderService.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key] public int Id { get; set; }
    }
}