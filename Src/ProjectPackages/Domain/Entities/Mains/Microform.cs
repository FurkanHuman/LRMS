using Core.Domain.Abstract;
using Domain.Entities.Bases;

namespace Domain.Entities.Mains;

public class Microform : MaterialBase, IEntity
{
    public string Scale { get; set; }

    public IList<Kit> Kits { get; set; }
}
