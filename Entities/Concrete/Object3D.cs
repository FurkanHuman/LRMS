using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Object3D : MaterialBase, IEntity
    {
        [Required]
        public string Owner { get; set; }

        [Required]
        public List<Image> Images { get; set; }

        public bool IsDestroyed { get; set; }
    }
}
