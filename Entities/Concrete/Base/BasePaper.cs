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
        public Guid FirstPagePeopleId { get; set; }

        [Required]
        public Guid TechnicalNumberId { get; set; }

        [Required]
        public Guid EditionId { get; set; }

        public bool IsDeleted { get; set; }

        public IList<CoverCap> CoverCaps { get; set; }
        
        public IList<Image> CoverImages { get; set; }

        public IList<FirstPagePersonBase> FirstPagePeople { get; set; }

        public IList<TechnicalNumber> TechnicalNumbers { get; set; }

        public IList<Edition> Editions { get; set; }
    }
}
