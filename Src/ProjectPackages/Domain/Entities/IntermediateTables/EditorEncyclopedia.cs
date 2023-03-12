// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class EditorEncyclopedia : BaseEntity<Guid>, IEntity
{
    public Guid EditorId { get; set; }

    public Editor Editor { get; set; }

    public Guid EncyclopediaId { get; set; }

    public Encyclopedia Encyclopedia { get; set; }
}
