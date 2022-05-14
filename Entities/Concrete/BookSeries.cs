using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class BookSeries : BasePaper, IEntity
    {
        [Required]
        public List<Book> Books { get; set; }
    }
}
