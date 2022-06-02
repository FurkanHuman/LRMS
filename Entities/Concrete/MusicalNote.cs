using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class MusicalNote : MaterialBase,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Composer Composer { get; set; }

        [Required]
        public DateTime DateOfWriting { get; set; }

        public bool IsSecret { get; set; }
    }
}