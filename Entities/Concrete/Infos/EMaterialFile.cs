using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class EMaterialFile : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FileName { get; set; }

        public string Title { get; set; }

        public string FilePath { get; set; }

        public double FileSizeMB { get; set; }

        public bool IsSecret { get; set; }

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
