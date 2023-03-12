// this file was created automatically.
using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Infos;
using Domain.Entities.Mains;

namespace Domain.Entities.IntermediateTables;

public class BookSeriesGraphicDesigner : BaseEntity<Guid>, IEntity
{
    public Guid BookSeriesId { get; set; }

    public BookSeries BookSeries { get; set; }

    public Guid GraphicDesignId { get; set; }

    public GraphicDesigner GraphicDesigner { get; set; }
}
