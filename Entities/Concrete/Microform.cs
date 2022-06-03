using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Microform : MaterialBase, IEntity
    {
        [Required]
        public string Scale { get; set; }
    }
}
