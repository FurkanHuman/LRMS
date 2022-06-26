using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Painting : MaterialBase, IEntity
    {
        [Required]
        public string Owner { get; set; }

        [Required]
        public Guid ImageId { get; set; }

        public bool IsDestroyed { get; set; }

        public Image Image { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
