using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Microform : MaterialBase,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Scale { get; set; }
    }
}
