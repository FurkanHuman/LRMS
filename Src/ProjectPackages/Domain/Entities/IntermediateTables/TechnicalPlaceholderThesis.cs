// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class TechnicalPlaceholderThesis : BaseEntity<Guid>, IEntity
{
    public Guid TechnicalPlaceholderId { get; set; }

    public TechnicalPlaceholder TechnicalPlaceholder { get; set; }

    public Guid ThesisId { get; set; }

    public Thesis Thesis { get; set; }
}
