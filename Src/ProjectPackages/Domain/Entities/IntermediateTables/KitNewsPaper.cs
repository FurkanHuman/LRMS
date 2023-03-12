// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class KitNewsPaper : BaseEntity<Guid>, IEntity
{
    public Guid KitId { get; set; }

    public Kit Kit { get; set; }

    public Guid NewsPaperId { get; set; }

    public NewsPaper NewsPaper { get; set; }
}
