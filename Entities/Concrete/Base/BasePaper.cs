using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Base
{
    public class BasePaper : MaterialBase
    {
        [Required]
        public List<Writer> Writers { get; set; }

        [Required]
        public Image CoverImage { get; set; }

        [Required]
        public CoverCap CoverCap { get; set; }

        [Required]
        public List<Editor> Editors { get; set; }

        [Required]
        public List<Director> Directors { get; set; }

        [Required]
        public List<GraphicDirector> GraphicDirectors { get; set; }

        [Required]
        public List<GraphicDesign> GraphicDesigns { get; set; }

        [Required]
        public List<Redaction> Redactions { get; set; }

        public List<Interpreters> Interpreters { get; set; }

        [Required]
        public List<TechnicalNumber> TechnicalNumbers { get; set; }

        [Required]
        public List<Edition> Editions { get; set; }

        [Required]
        public List<Publisher> Publishers { get; set; }

        [Required]
        public List<Communication> Communication { get; set; }

        public bool IsDeleted { get; set; }
    }
}
