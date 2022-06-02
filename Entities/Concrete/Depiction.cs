using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Depiction : MaterialBase,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Image Image { get; set; }
    }
}
