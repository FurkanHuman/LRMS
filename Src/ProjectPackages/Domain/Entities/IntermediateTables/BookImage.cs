// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class BookImage : BaseEntity<Guid>, IEntity
{
    public Guid BookId { get; set; }

    public Book Book { get; set; }

    public Guid ImageId { get; set; }

    public Image Image { get; set; }


}
