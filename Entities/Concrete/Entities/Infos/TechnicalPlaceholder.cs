using Core.Entities.Abstract;
using Entities.Concrete.Entities.Mains;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Infos
{
    public class TechnicalPlaceholder : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid LibraryId { get; set; }

        public Library Library { get; set; }

        [Required, MaxLength(12)]
        public string ColumnCode { get; set; }

        [Required, MaxLength(12)]
        public string RowCode { get; set; }

        [MaxLength(56)]
        public string? SpecialLocation { get; set; }

        public bool IsDeleted { get; set; }

        public IList<AcademicJournal> AcademicJournals { get; set; }
        public IList<AudioRecord> AudioRecords { get; set; }
        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<CartographicMaterial> CartographicMaterials { get; set; }
        public IList<Depiction> Depictions { get; set; }
        public IList<Dissertation> Dissertations { get; set; }
        public IList<ElectronicsResource> ElectronicsResources { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<GraphicalImage> GraphicalImages { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<Microform> Microforms { get; set; }
        public IList<MusicalNote> MusicalNotes { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
        public IList<Object3D> Object3Ds { get; set; }
        public IList<Painting> Paintings { get; set; }
        public IList<Poster> Posters { get; set; }
        public IList<Thesis> Theses { get; set; }
    }
}
