using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Object3D : MaterialBase, IEntity
    {
        [Required]
        public OtherPeople Owner { get; set; }

        [Required]
        public Guid ImageId { get; set; }

        public bool IsDestroyed { get; set; }

        public IList<Image> Images { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
