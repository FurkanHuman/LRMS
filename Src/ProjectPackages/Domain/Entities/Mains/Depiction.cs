using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class Depiction : MaterialBase, IEntity
{
    public Guid ImageId { get; set; }

    public Image Image { get; set; }

    public IList<Kit> Kits { get; set; }
}
