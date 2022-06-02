using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Dissertation : MaterialBase,IEntity //  akedemik araştırma... tezin bir üstü
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public University University { get; set; }

        [Required]
        public Researcher Researcher { get; set; }

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
    }
}
