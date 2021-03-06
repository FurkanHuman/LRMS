using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Depiction : MaterialBase, IEntity
    {
        [Required]
        public Image Image { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
