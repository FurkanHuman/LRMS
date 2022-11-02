using Core.Domain.Abstract;

namespace Domain.Entities.Infos;

public class Stock : IEntity
{
    public Guid Id { get; set; }

    public Guid LibraryId { get; set; }

    public Library Library { get; set; }

    public string StockCode { get; set; }

    public uint Quantity { get; set; } = 1;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }

}
