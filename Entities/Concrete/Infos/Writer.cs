using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete.Infos
{

    public class Writer : FirstPagePersonBase, IEntity
    {
        public string NamePreAttachment { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
    }
}