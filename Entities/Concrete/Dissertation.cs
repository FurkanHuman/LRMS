using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Dissertation : MaterialBase, IEntity //  akedemik araştırma... tezin bir üstü
    {
        [Required]
        public Guid UniversityId { get; set; }

        [Required]
        public Guid ResearcherId { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public ushort DateTimeYear { get; set; }

        [Required]
        public int DissertationNumber { get; set; }

        [Required]
        public bool PermissionStatus { get; set; }

        [Required]
        public bool ApprovalStatus { get; set; }

        public bool IsSecret { get; set; }

        public IList<University> University { get; set; }
        public IList<Researcher> Researcher { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}
