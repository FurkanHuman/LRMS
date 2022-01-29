using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Magazine : BasePaper, IEntity
    {
        [Required, MaxLength(128)]
        public string Subject { get; set; }
    }
}
