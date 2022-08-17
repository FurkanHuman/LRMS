using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Mains
{
    public class Microform : MaterialBase, IEntity
    {
        [Required]
        public string Scale { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
