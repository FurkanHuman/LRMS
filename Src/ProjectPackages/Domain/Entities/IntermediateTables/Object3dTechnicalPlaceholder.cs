// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class Object3dTechnicalPlaceholder : BaseEntity<Guid>, IEntity
{
    public Guid Object3DId { get; set; }

    public Object3D Object3D { get; set; }

    public Guid TechnicalPlaceholderId { get; set; }

    public TechnicalPlaceholder TechnicalPlaceholder { get; set; }
}
