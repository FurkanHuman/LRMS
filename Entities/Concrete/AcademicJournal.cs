using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class AcademicJournal : MaterialBase, IEntity
    {
        [Required]
        public List<Researcher> Researchers { get; set; }

        [Required]
        public List<Editor> Editors { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required]
        public ushort DateOfYear { get; set; }

        [Required]
        public ushort Volume { get; set; }

        [Required]
        public ushort No { get; set; }

        [Required]
        public ushort StartPageNumber { get; set; }

        [Required]
        public ushort EndPageNumber { get; set; }
    }
}
