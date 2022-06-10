using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class MusicalNote : MaterialBase, IEntity
    {
        [Required]
        public Guid ComposerId { get; set; }

        [Required]
        public DateTime DateOfWriting { get; set; }

        public bool IsSecret { get; set; }

        public IList<Composer> Composers { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}