using Core.Entities.Abstract;

namespace Entities.Concrete.FirstPage
{

    public class Writer : FirstPagePersonBase, IEntity
    {
        public string NamePreAttachment { get; set; }
    }
}