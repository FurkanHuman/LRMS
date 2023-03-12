// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class KitMicroform : BaseEntity<Guid>, IEntity
{
    public Guid KitId { get; set; }

    public Kit Kit { get; set; }

    public Guid MicroformId { get; set; }

    public Microform Microform { get; set; }
}
