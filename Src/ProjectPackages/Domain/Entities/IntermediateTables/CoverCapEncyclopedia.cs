// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class CoverCapEncyclopedia : BaseEntity<Guid>, IEntity
{
    public short CoverCapId { get; set; }

    public CoverCap CoverCap { get; set; }

    public Guid EncyclopediaId { get; set; }

    public Encyclopedia Encyclopedia { get; set; }
}
