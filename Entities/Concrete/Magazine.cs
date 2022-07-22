using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Magazine : BasePaper, IEntity
    {
        [Required]
        public byte MagazineType { get; set; }

        public uint Volume { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
