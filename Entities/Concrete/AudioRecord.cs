using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class AudioRecord : MaterialBase, IEntity
    {
        [Required]
        public string Owner { get; set; } // change a otherPeople class todo

        [Required]
        public DateTime RecordDate { get; set; }

        public DateTime RecordEndDate { get; set; }

        public float RecordingLength { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
