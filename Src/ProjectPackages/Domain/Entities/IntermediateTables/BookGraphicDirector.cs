// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class BookGraphicDirector : BaseEntity<Guid>, IEntity
{
    public Guid BookId { get; set; }

    public Book Book { get; set; }

    public Guid GraphicDirectorId { get; set; }

    public GraphicDirector GraphicDirector { get; set; }
}
