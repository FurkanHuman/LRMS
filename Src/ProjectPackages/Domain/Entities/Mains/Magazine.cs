using Core.Domain.Abstract;
using Domain.Entities.Bases;

namespace Domain.Entities.Mains;

public class Magazine : BasePaper, IEntity
{
    public byte MagazineType { get; set; }

    public uint Volume { get; set; }

    public IList<Kit> Kits { get; set; }
}
