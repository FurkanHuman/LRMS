using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Encyclopedia : BasePaper, IEntity  // Todo: add referece entity but LATER
    {
        [Required]
        public uint SequenceNumber { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
