// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class CategoryKit : BaseEntity<Guid>, IEntity
{
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
