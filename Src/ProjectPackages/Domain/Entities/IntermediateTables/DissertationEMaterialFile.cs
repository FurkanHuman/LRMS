// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class DissertationEMaterialFile : BaseEntity<Guid>, IEntity
{
    public Guid DissertationId { get; set; }

    public Dissertation Dissertation { get; set; }

    public Guid EMaterialFileId { get; set; }

    public EMaterialFile EMaterialFile { get; set; }
}
