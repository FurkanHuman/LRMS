using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Base
{
    public class BasePaper : MaterialBase
    {
        [Required]
        public Image CoverImage { get; set; }

        [Required]
        public CoverCap CoverCap { get; set; }

        [Required]
        public List<FirstPagePersonBase> FirstPagePeople { get; set; }

        [Required]
        public List<TechnicalNumber> TechnicalNumbers { get; set; }

        [Required]
        public List<Edition> Editions { get; set; }
        
        [Required]
        public List<Publisher> Publishers { get; set; }

        public bool IsDeleted { get; set; }
    }
}
