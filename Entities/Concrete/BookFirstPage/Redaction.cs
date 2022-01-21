using Core.Entities.Abstract;

namespace Entities.Concrete.BookFirstPage
{
    public class Redaction : BookFirstPagePersonBase, IEntity
    {
        public Redaction(string name, string surName) : base(name, surName) { }
    }
}
