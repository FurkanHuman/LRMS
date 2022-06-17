using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Base
{
    public class BasePaper : MaterialBase
    {
        [Required]
        public byte CoverCapId { get; set; }

        [Required]
        public Guid CoverImageId { get; set; }

        [Required]
        public Guid WriterId { get; set; }

        [Required]
        public Guid EditorId { get; set; }

        public Guid? DirectorId { get; set; }

        public Guid? GraphicDesignId { get; set; }

        public Guid? GraphicDirectorId { get; set; }

        public Guid? InterpretersId { get; set; }

        public Guid? RedactionId { get; set; }

        public Guid? OtherPeopleId { get; set; }

        [Required]
        public Guid TechnicalNumberId { get; set; }

        [Required]
        public Guid EditionId { get; set; }

        public IList<CoverCap> CoverCaps { get; set; }

        public IList<Image> CoverImages { get; set; }

        public IList<Writer> Writers { get; set; }

        public IList<Editor> Editors { get; set; }

        public IList<Director>? Directors { get; set; }

        public IList<GraphicDesigner>? GraphicDesigns { get; set; }

        public IList<GraphicDirector>? GraphicDirectors { get; set; }

        public IList<Interpreters>? Interpreters { get; set; }

        public IList<Redaction>? Redactions { get; set; }

        public IList<OtherPeople>? OtherPeoples { get; set; }

        public IList<TechnicalNumber> TechnicalNumbers { get; set; }

        public IList<Edition> Editions { get; set; }
    }
}
