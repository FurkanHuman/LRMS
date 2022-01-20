using Core.Entities.Abstract;

namespace Entities.Concrete.BookFirstPage
{

    public class BookWriter : BookFirstPagePersonBase, IEntity
    {
        public string? NamePreAttachment { get; set; }
    }
}