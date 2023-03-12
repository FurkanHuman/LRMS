// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.IntermediateTables;

public class CloudStorageImage : BaseEntity<Guid>, IEntity
{
    public long CloudStorageServiceId { get; set; }

    public CloudStorage CloudStorage { get; set; }

    public Guid ImageId { get; set; }

    public Image Image { get; set; }


}
