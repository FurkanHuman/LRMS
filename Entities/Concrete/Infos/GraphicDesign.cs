using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete.Infos
{
    public class GraphicDesign : FirstPagePersonBase, IEntity
    {
        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
    }
}
