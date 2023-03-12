// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class DepictionKit : BaseEntity<Guid>, IEntity
{
    public Guid DepictionId { get; set; }

    public Depiction Depiction { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
