using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class AudioRecord : MaterialBase, IEntity
    {
        [Required]
        public DateTime RecordDate { get; set; }

        public byte SecretLevel { get; set; }
    }
}
