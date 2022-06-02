using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    // fix it
    public class Encyclopedia : BasePaper,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public int SequenceNumber { get; set; }
    }
}
