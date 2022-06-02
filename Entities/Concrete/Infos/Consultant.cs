using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete.Infos
{
    public class Consultant : FirstPagePersonBase,IEntity
    {
        public string? NamePreAttachment { get; set; }
    }
}
