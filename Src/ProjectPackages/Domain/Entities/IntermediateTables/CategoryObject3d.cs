// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class CategoryObject3d : BaseEntity<Guid>, IEntity
{
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public Guid Object3DId { get; set; }

    public Object3D Object3D { get; set; }
}
