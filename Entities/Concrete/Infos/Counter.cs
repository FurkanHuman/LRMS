using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Counter : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public long Count { get; set; }

        public bool IsDeleted { get; set; }
    }
}
