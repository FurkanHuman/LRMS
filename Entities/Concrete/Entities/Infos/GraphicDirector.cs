using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class GraphicDirector : FirstPagePersonBase, IEntity
    {
        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}
