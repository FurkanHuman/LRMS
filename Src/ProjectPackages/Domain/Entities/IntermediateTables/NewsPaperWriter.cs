// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class NewsPaperWriter : BaseEntity<Guid>, IEntity
{
    public Guid NewsPaperId { get; set; }

    public NewsPaper NewsPaper { get; set; }

    public Guid WriterId { get; set; }

    public Writer Writer { get; set; }
}
