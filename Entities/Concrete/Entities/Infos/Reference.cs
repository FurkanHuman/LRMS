using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class Reference : BaseEntity<Guid>, IEntity // kaynakça 
    {
        [Required]
        public string Owner { get; set; }

        public ushort StartPageNumber { get; set; }

        public ushort EndPageNumber { get; set; }

        [Required]
        public Guid TechnicalNumberId { get; set; }

        public TechnicalNumber TechnicalNumber { get; set; }

        [Required]
        public DateTime ReferenceDate { get; set; }

        public IList<AcademicJournal> AcademicJournals { get; set; }

        public IList<Book> Books { get; set; }
    }
}
