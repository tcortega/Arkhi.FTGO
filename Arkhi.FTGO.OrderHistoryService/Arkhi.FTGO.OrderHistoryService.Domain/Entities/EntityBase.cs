using System.ComponentModel.DataAnnotations;

namespace Arkhi.FTGO.OrderHistoryService.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key] public int Id { get; set; }
    }
}