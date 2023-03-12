// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class KitMusicalNote : BaseEntity<Guid>, IEntity
{
    public Guid KitId { get; set; }

    public Kit Kit { get; set; }

    public Guid MusicalNoteId { get; set; }

    public MusicalNote MusicalNote { get; set; }
}
