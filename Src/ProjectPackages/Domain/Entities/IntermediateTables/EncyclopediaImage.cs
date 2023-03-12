// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class EncyclopediaImage : BaseEntity<Guid>, IEntity
{
    public Guid EncyclopediaId { get; set; }

    public Encyclopedia Encyclopedia { get; set; }

    public Guid ImageId { get; set; }

    public Image Image { get; set; }


}
