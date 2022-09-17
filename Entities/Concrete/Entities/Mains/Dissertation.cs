namespace Entities.Concrete.Entities.Mains
{
    public class Dissertation : MaterialBase, IEntity //  akedemik araştırma... tezin bir üstü
    {
        public Guid UniversityId { get; set; }

        public Guid ResearcherId { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public ushort DateTimeYear { get; set; }

        public int DissertationNumber { get; set; }

        public bool ApprovalStatus { get; set; }

        public IList<University> University { get; set; }
        public IList<Researcher> Researcher { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}
