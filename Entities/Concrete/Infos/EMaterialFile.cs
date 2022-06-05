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
    }
}
