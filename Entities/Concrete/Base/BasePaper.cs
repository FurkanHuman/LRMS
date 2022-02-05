using Core.Entities.Abstract;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Base
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
        public List<Director> Directors{ get; set; }

        [Required]
        public List<GraphicDirector> GraphicDirectors  { get; set; }

        [Required]
        public List<GraphicDesign> GraphicDesigns { get; set; }

        [Required]
        public List<Redaction> Redactions { get; set; }

        public List<Interpreters> Interpreters { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required]
        public TechnicalNumber TechnicalNumber { get; set; }

        public TechnicalPlaceholder? TechnicalPlaceholder { get; set; }

        public bool IsDeleted { get; set; }

    }
}
