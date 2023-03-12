// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class DissertationKit : BaseEntity<Guid>, IEntity
{
    public Guid DissertationId { get; set; }

    public Dissertation Dissertation { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
