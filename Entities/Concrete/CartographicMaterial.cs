using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CartographicMaterial : MaterialBase, IEntity
    {
        [Required]
        public DateTime Date { get; set; }
    }
}
