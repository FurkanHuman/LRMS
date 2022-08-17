using Core.Entities.Abstract;
using Entities.Concrete.Entities.Mains;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Infos
{
    public class Edition : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Required]
        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        [Required]
        public int EditionNumber { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}
