// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class EncyclopediaKit : BaseEntity<Guid>, IEntity
{
    public Guid EncyclopediaId { get; set; }

    public Encyclopedia Encyclopedia { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
