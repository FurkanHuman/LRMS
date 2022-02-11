using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Researcher : FirstPagePersonBase, IEntity
    {
        public string? NamePreAttachment { get; set; }

        [Required]
        public string Specialty { get; set; }
    }
}
