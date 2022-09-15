using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class Edition : BaseEntity<Guid>, IEntity
    {
        [Required]
        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        [Required]
        public int EditionNumber { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}
