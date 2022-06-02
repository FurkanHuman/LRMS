using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class GraphicalImage : MaterialBase,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime ImageCreatedDate { get; set; }

        public bool IsDestroyed { get; set; }
    }
}
