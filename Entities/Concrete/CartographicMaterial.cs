using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class CartographicMaterial : MaterialBase, IEntity
    {
        public DateTime Date { get; set; }
    }
}
