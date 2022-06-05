using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class CoverCap : IEntity
    {   // kitap kapağı tipi, karton, deri,  vs vs
        [Key]
        public byte Id { get; set; }

        public string BookSkinType { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }

    }
}
