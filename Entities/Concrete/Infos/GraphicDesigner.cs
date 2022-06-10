using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete.Infos
{
    public class GraphicDesigner : FirstPagePersonBase, IEntity
    {
        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}
