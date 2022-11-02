using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class CoverCap : BaseEntity<byte>, IEntity
{   // kitap kapağı tipi, karton, deri,  vs vs
    public IList<Book> Books { get; set; }
    public IList<BookSeries> BookSeries { get; set; }
    public IList<Encyclopedia> Encyclopedias { get; set; }
    public IList<Magazine> Magazines { get; set; }
    public IList<NewsPaper> NewsPapers { get; set; }
}
