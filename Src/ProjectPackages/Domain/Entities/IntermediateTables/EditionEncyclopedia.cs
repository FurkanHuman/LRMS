// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class EditionEncyclopedia : BaseEntity<Guid>, IEntity
{
    public Guid EditionId { get; set; }

    public Edition Edition { get; set; }

    public Guid EncyclopediaId { get; set; }

    public Encyclopedia Encyclopedia { get; set; }
}
