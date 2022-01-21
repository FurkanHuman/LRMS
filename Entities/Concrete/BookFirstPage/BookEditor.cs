using Core.Entities.Abstract;
namespace Entities.Concrete.BookFirstPage
{
    public class BookEditor : BookFirstPagePersonBase, IEntity
    {
        public BookEditor(string name, string surName) : base(name, surName)
        {
        }
    }
}
