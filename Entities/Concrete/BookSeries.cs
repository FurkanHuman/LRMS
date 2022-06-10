using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class BookSeries : BasePaper, IEntity
    {
        [Required]
        public Guid BookIds { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
