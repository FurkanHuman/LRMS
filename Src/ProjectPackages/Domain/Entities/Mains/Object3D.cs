using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class Object3D : MaterialBase, IEntity
{
    public Guid OwnerId { get; set; }

    public OtherPeople Owner { get; set; }

    public Guid ImageId { get; set; }

    public bool IsDestroyed { get; set; }

    public IList<Image> Images { get; set; }

    public IList<Kit> Kits { get; set; }
}
