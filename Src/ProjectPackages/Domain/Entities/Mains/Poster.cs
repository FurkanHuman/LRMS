using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class Poster : MaterialBase, IEntity
{
    public Guid OtherPeopleId { get; set; }

    public OtherPeople Owner { get; set; }

    public Guid ImageId { get; set; }

    public bool IsDestroyed { get; set; }

    public Image Image { get; set; }

    public IList<Kit> Kits { get; set; }
}
