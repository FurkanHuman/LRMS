using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class OtherPeople : FirstPagePersonBase, IEntity
    {
        [Required]
        public string Title { get; set; }

        public string? NamePreAttachment { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
    }
}
