// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class EncyclopediaInterpreters : BaseEntity<Guid>, IEntity
{
    public Guid EncyclopediaId { get; set; }

    public Encyclopedia Encyclopedia { get; set; }

    public Guid İnterpretersId { get; set; }

    public Interpreters Interpreters { get; set; }


}
