using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using Entities.Concrete.Entities.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Mains
{
    public class Depiction : MaterialBase, IEntity
    {
        [Required]
        public Guid ImageId { get; set; }

        public Image Image { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
