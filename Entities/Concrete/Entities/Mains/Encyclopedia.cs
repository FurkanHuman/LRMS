using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Mains
{
    public class Encyclopedia : BasePaper, IEntity  // Todo: add referece entity but LATER
    {
        [Required]
        public uint SequenceNumber { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
