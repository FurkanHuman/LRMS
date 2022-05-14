using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Kit : MaterialBase, IEntity
    {
        [Required]
        public List<IEntity> Entities { get; set; }

        public byte SecretLevel { get; set; }
    }
}
