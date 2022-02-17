using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class BookSeries : BasePaper, IEntity
    {
        public List<Book> Books { get; set; }
    }
}
