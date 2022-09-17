using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class Reference : BaseEntity<Guid>, IEntity // kaynakça 
    {
        public Guid OwnerId { get; set; }

        public OtherPeople Owner { get; set; }

        public ushort StartPageNumber { get; set; }

        public ushort EndPageNumber { get; set; }

        public Guid TechnicalNumberId { get; set; }

        public TechnicalNumber TechnicalNumber { get; set; }

        public DateTime ReferenceDate { get; set; }

        public IList<AcademicJournal> AcademicJournals { get; set; }

        public IList<Encyclopedia> Encyclopedias { get; set; }

        public IList<Book> Books { get; set; }
    }
}
