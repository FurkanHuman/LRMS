using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Mains
{
    public class Magazine : BasePaper, IEntity
    {
        [Required]
        public byte MagazineType { get; set; }

        public uint Volume { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
