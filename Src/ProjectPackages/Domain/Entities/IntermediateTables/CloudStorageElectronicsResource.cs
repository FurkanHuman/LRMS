// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class CloudStorageElectronicsResource : BaseEntity<Guid>, IEntity
{
    public long CloudStorageId { get; set; }

    public CloudStorage CloudStorage { get; set; }

    public Guid ElectronicsResourceId { get; set; }

    public ElectronicsResource ElectronicsResource { get; set; }
}
