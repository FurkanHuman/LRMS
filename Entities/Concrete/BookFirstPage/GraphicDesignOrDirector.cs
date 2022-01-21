using Core.Entities.Abstract;
namespace Entities.Concrete.BookFirstPage
{
    public class GraphicDesignOrDirector : BookFirstPagePersonBase, IEntity
    {
        public GraphicDesignOrDirector(string name, string surName) : base(name, surName)
        {
        }
    }
}
