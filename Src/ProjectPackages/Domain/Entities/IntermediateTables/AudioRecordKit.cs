// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class AudioRecordKit : BaseEntity<Guid>, IEntity
{
    public Guid AudioRecordId { get; set; }

    public AudioRecord AudioRecord { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
