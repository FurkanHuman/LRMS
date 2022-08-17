using Core.Entities.Abstract;
using Entities.Concrete.Entities.Mains;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Infos
{
    public class CoverCap : IEntity
    {   // kitap kapağı tipi, karton, deri,  vs vs
        [Key]
        public byte Id { get; set; }

        public string BookSkinType { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}
