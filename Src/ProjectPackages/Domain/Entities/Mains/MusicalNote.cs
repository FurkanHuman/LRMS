using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class MusicalNote : MaterialBase, IEntity
{
    public Guid ComposerId { get; set; }

    public DateTime DateOfWriting { get; set; }

    public Composer Composer { get; set; }
    public IList<Kit> Kits { get; set; }
}