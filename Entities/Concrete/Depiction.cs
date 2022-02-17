using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;

namespace Entities.Concrete
{
    public class Depiction : MaterialBase, IEntity
    {
        public Image Image { get; set; }
    }
}
