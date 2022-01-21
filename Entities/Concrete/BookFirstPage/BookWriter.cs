using Core.Entities.Abstract;

namespace Entities.Concrete.BookFirstPage
{

    public class BookWriter : BookFirstPagePersonBase, IEntity
    {
        public BookWriter(string name, string surName) : base(name, surName) { }

        public string? NamePreAttachment { get; set; }
    }
}