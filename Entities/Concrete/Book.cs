using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Book : BasePaper,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string? OriginalBookName { get; set; }
    }
}
