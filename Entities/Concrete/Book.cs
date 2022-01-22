using Core.Entities.Abstract;
using Entities.Concrete.BookFirstPage;
using Entities.Concrete.BookCover;
using NHibernate.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required, MaxLength(512)]
        public string BookName { get; set; }

        [Required]
        public List<BookCategory> BookCategorys { get; set; }

        [Required]
        public List<BookWriter> BookWriters { get; set; }

        [Required]
        public BookCoverCap BookCoverCap { get; set; }

        [Required]
        public BookCoverImage BookCoverImage { get; set; }

        [Required]
        public List<BookEditor> BookEditors { get; set; }

        [Required]
        public List<Redaction> Redactions { get; set; }

        public List<Interpreters> MyProperty { get; set; }

        [Required]
        public List<GraphicDesignOrDirector> GraphicDesignOrs { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required]
        public BookTechnicalNumber BookTechnicalNumber { get; set; }

    }
}
