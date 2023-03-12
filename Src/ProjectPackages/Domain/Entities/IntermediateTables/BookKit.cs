// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class BookKit : BaseEntity<Guid>, IEntity
{
    public Guid BookId { get; set; }

    public Book Book { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
