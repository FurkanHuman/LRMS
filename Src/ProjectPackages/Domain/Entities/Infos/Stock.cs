using Core.Domain.Abstract;
using Core.Domain.Bases;
using System.Collections.Specialized;

namespace Domain.Entities.Infos;

public class Stock : BaseEntity<Guid>,IEntity
{
    public Guid LibraryId { get; set; }

    public Library Library { get; set; }

    public string StockCode { get; set; }

    public uint Quantity { get; set; } = 1;
}
