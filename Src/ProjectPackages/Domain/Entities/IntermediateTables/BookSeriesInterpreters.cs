// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class BookSeriesInterpreters : BaseEntity<Guid>, IEntity
{
    public Guid BookSeriesId { get; set; }

    public BookSeries BookSeries { get; set; }

    public Guid InterpretersId { get; set; }

    public Interpreters Interpreters { get; set; }


}
