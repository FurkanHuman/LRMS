using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;

namespace Entities.Concrete.Entities.Mains
{
    public class ElectronicsResource : MaterialBase, IEntity // elec res type cahnge a structre
    {
        public string ResourceUrl { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}