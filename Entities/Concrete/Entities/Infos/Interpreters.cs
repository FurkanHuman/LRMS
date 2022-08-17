using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using Entities.Concrete.Entities.Mains;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Infos
{
    public class Interpreters : FirstPagePersonBase, IEntity
    {// çevirenler hangi dilden cevirdi
        [MaxLength(32)]
        public string WhichToLanguage { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}