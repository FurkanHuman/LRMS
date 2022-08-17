namespace Entities.Concrete.Entities.Mains
{
    public class Book : BasePaper, IEntity
    {
        public string? OriginalBookName { get; set; }

        [Required]
        public Guid ReferenceId { get; set; }

        public IList<Reference> References { get; set; }

        public IList<BookSeries> BookSeries { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
