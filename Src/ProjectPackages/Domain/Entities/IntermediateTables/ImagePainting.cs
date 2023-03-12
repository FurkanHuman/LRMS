// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class ImagePainting : BaseEntity<Guid>, IEntity
{
    public Guid ImageId { get; set; }

    public Image Image { get; set; }

    public Guid PaintingId { get; set; }

    public Painting Painting { get; set; }


}
