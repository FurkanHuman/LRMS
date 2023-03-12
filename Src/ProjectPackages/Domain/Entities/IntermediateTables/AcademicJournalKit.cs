// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class AcademicJournalKit : BaseEntity<Guid>, IEntity
{
    public Guid AcademicJournalId { get; set; }

    public AcademicJournal AcademicJournal { get; set; }

    public Guid KitId { get; set; }

    public Kit Kit { get; set; }
}
