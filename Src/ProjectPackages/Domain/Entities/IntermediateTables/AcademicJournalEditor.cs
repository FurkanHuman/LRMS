// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class AcademicJournalEditor : BaseEntity<Guid>, IEntity
{
    public Guid AcademicJournalId { get; set; }

    public AcademicJournal AcademicJournal { get; set; }

    public Guid EditorId { get; set; }

    public Editor Editor { get; set; }
}
