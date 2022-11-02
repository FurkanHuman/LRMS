using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class Book : BasePaper, IEntity
{
    public string? OriginalBookName { get; set; }

    public Guid ReferenceId { get; set; }

    public IList<Reference> References { get; set; }

    public IList<BookSeries> BookSeries { get; set; }

    public IList<Kit> Kits { get; set; }
}
