using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Thesis : MaterialBase, IEntity
    {
        [Required]
        public University University { get; set; }

        [Required]
        public byte ThesisDegree { get; set; }

        [Required]
        public Researcher Researcher { get; set; }

        [Required]
        public Consultant Consultant { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public ushort DateTimeYear { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        public int ThesisNumber { get; set; }

        [Required]
        public bool PermissionStatus { get; set; }

        [Required]
        public bool ApprovalStatus { get; set; }

        [Required]
        public bool IsSecret { get; set; }
    }
}
