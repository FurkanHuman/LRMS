using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Encyclopedia : BasePaper, IEntity
    {
        [Required]
        public int SequenceNumber { get; set; }
    }
}
