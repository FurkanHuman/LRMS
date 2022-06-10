using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Thesis : MaterialBase, IEntity
    {
        [Required]
        public Guid UniversityId { get; set; }

        [Required]
        public byte ThesisDegree { get; set; }

        [Required]
        public Guid ResearcherId { get; set; }

        [Required]
        public Guid ConsultantId { get; set; }

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

        public bool IsSecret { get; set; }

        public Consultant Consultant { get; set; }
        public University University { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}
