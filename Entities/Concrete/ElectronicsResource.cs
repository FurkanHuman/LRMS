using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class ElectronicsResource : MaterialBase, IEntity // elec res type cahnge a structre
    {
        public string ResourceUrl { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}