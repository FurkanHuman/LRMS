// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class ElectronicsResourceTechnicalPlaceholder : BaseEntity<Guid>, IEntity
{
    public Guid ElectronicsResourceId { get; set; }

    public ElectronicsResource ElectronicsResource { get; set; }

    public Guid TechnicalPlaceholderId { get; set; }

    public TechnicalPlaceholder TechnicalPlaceholder { get; set; }
}
