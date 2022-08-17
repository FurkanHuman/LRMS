using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class Consultant : FirstPagePersonBase, IEntity
    {
        public string? NamePreAttachment { get; set; }

        public IList<Thesis> Theses { get; set; }
    }
}
