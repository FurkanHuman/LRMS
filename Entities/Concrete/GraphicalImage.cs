using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class GraphicalImage : MaterialBase, IEntity
    {
        [Required]
        public DateTime ImageCreatedDate { get; set; }

        public OtherPeople OtherPeople { get; set; }

        public bool IsDestroyed { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
