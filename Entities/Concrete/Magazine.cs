using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Magazine : BasePaper,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Subject { get; set; }
    }
}
