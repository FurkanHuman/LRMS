using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Domain.Entities.Infos;

public class Counter : BaseEntity<Guid>, IEntity
{
    public ulong Count { get; set; }
}
