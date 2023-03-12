// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class EditorMagazine : BaseEntity<Guid>, IEntity
{
    public Guid EditorId { get; set; }

    public Editor Editor { get; set; }

    public Guid MagazineId { get; set; }

    public Magazine Magazine { get; set; }
}
