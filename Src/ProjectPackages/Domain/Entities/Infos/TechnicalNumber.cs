using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class TechnicalNumber : BaseEntity<Guid>, IEntity
{
    public long Barcode { get; set; }

    public ulong ISBN { get; set; }

    public ulong? ISSN { get; set; }

    public string? CertificateCode { get; set; }

    public IList<Book> Books { get; set; }
    public IList<BookSeries> BookSeries { get; set; }
    public IList<Encyclopedia> Encyclopedias { get; set; }
    public IList<Magazine> Magazines { get; set; }
    public IList<NewsPaper> NewsPapers { get; set; }
}