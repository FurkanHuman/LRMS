using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Edition : Publisher, IEntity
    {
        [Required]
        public int EditionNumber { get; set; }
    }
}
