using System.ComponentModel.DataAnnotations;

namespace Arkhi.FTGO.CustomerService.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key] public int Id { get; set; }

        public bool IsActive { get; set; } = true;
    }
}