using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Reference : IEntity // kaynakça 
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string SubText { get; set; }

        [Required]
        public string Owner { get; set; }

        public ushort StartPageNumber { get; set; }

        public ushort EndPageNumber { get; set; }

        [Required]
        public Guid TechnicalNumberId { get; set; }

        public TechnicalNumber TechnicalNumber { get; set; }

        [Required]
        public DateTime ReferenceDate { get; set; }

        public bool IsDeleted { get; set; }

        public IList<AcademicJournal> AcademicJournals { get; set; }

        public IList<Book> Books { get; set; }
    }
}
