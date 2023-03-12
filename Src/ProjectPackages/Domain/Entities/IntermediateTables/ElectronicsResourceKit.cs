// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class ElectronicsResourceKit : BaseEntity<Guid>, IEntity
{
    public Guid ElectronicsResourceId { get; set; }

    public ElectronicsResource ElectronicsResource { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
