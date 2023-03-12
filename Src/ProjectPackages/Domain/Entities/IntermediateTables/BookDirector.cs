// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class BookDirector : BaseEntity<Guid>, IEntity
{
    public Guid BookId { get; set; }

    public Book Book { get; set; }

    public Guid DirectorId { get; set; }

    public Director Director { get; set; }
}
