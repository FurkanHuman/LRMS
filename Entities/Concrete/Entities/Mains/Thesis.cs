namespace Entities.Concrete.Entities.Mains
{
    public class Thesis : MaterialBase, IEntity
    {
        [Required]
        public Guid UniversityId { get; set; }

        [Required]
        public byte ThesisDegree { get; set; }

        [Required]
        public Guid ResearcherId { get; set; }

        public Researcher Researcher { get; set; }

        [Required]
        public Guid ConsultantId { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }

        [Required]
        public ushort DateTimeYear { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [Required]
        public int ThesisNumber { get; set; }

        [Required]
        public bool PermissionStatus { get; set; }

        [Required]
        public bool ApprovalStatus { get; set; }

        public Consultant Consultant { get; set; }
        public University University { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}
