// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.IntermediateTables;

public class CloudStorageEMaterialFile : BaseEntity<Guid>, IEntity
{
    public long CloudStorageId { get; set; }

    public CloudStorage CloudStorage { get; set; }

    public Guid EMaterialFileId { get; set; }

    public EMaterialFile EMaterialFile { get; set; }
}
