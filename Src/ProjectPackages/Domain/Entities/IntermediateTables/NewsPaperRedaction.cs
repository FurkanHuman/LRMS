// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class NewsPaperRedaction : BaseEntity<Guid>, IEntity
{
    public Guid NewsPaperId { get; set; }

    public NewsPaper NewsPaper { get; set; }

    public Guid RedactionId { get; set; }

    public Redaction Redaction { get; set; }
}
