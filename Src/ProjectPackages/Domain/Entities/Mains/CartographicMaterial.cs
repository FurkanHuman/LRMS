using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class CartographicMaterial : MaterialBase, IEntity
{
    public Guid ImageId { get; set; }

    public DateTime Date { get; set; }

    public IList<Image> Images { get; set; }

    public IList<Kit> Kits { get; set; }
}
