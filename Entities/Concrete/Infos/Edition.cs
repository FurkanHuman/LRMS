using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Edition : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required]
        public int EditionNumber { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
    }
}
