// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class MusicalNoteTechnicalPlaceholder : BaseEntity<Guid>, IEntity
{
    public Guid MusicalNoteId { get; set; }

    public MusicalNote MusicalNote { get; set; }

    public Guid TechnicalPlaceholderId { get; set; }

    public TechnicalPlaceholder TechnicalPlaceholder { get; set; }
}
