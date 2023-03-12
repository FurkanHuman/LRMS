// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class CartographicMaterialEMaterialFile : BaseEntity<Guid>, IEntity
{
    public Guid CartographicMaterialId { get; set; }

    public CartographicMaterial CartographicMaterial { get; set; }

    public Guid EMaterialFileId { get; set; }

    public EMaterialFile EMaterialFile { get; set; }
}
