using Core.Entities.Abstract;

namespace Entities.Concrete.BookCover
{
    public class BookCategory:IEntity
    {// category
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
