using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class Book : BasePaper, IEntity
    {
        public string? OriginalBookName { get; set; }

        public IList<BookSeries> BookSeries { get; set; }
    }
}
