using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class ElectronicsResource : MaterialBase, IEntity
    {
        public string ResourceUrl { get; set; }
    }
}
