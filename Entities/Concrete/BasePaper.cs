using Core.Entities.Abstract;
using Entities.Concrete.Cover;
using Entities.Concrete.FirstPage;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class BasePaper : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required, MaxLength(512)]
        public string Name { get; set; }

        [Required]
        public List<Category> Categorys { get; set; }

        [Required]
        public List<Writer> Writers { get; set; }

        [Required]
        public CoverCap CoverCap { get; set; }

        [Required]
        public CoverImage CoverImage { get; set; }

        [Required]
        public List<Editor> Editors { get; set; }

        [Required]
        public List<Redaction> Redactions { get; set; }

        public List<Interpreters> Interpreters { get; set; }

        [Required]
        public List<GraphicDesignOrDirector> GraphicDesignOrs { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required]
        public TechnicalNumber BookTechnicalNumber { get; set; }

        public bool IsDeleted { get; set; }

    }
}
