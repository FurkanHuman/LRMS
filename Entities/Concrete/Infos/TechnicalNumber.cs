using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class TechnicalNumber : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public long Barcode { get; set; }

        public ulong ISBN { get; set; }

        public ulong? ISSN { get; set; }

        [MaxLength(64)]
        public string? CertificateCode { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}