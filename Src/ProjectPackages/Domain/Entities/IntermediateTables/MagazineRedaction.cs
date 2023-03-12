// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class MagazineRedaction : BaseEntity<Guid>, IEntity
{
    public Guid MagazineId { get; set; }

    public Magazine Magazine { get; set; }

    public Guid RedactionId { get; set; }

    public Redaction Redaction { get; set; }
}
