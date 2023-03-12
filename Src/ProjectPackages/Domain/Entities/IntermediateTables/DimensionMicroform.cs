// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class DimensionMicroform : BaseEntity<Guid>, IEntity
{
    public Guid DimensionId { get; set; }

    public Dimension Dimension { get; set; }

    public Guid MicroformId { get; set; }

    public Microform Microform { get; set; }
}
