using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Magazine : BasePaper, IEntity
    {

        [Required, MaxLength(512)]
        public string Title { get; set; }
    }
}
