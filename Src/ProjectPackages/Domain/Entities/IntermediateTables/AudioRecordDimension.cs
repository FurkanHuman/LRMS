// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class AudioRecordDimension : BaseEntity<Guid>, IEntity
{
    public Guid AudioRecordId { get; set; }

    public AudioRecord AudioRecord { get; set; }

    public Guid DimensionId { get; set; }

    public Dimension Dimension { get; set; }
}
