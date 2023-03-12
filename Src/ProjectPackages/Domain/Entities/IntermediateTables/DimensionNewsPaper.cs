// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class DimensionNewsPaper : BaseEntity<Guid>, IEntity
{
    public Guid DimensionId { get; set; }

    public Dimension Dimension { get; set; }

    public Guid NewsPaperId { get; set; }

    public NewsPaper NewsPaper { get; set; }
}
