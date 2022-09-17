namespace Entities.Concrete.Entities.Infos
{
    public class Stock : IEntity
    {
        public Guid Id { get; set; }

        public Guid LibraryId { get; set; }

        public Library Library { get; set; }

        public string StockCode { get; set; }

        public uint Quantity { get; set; } = 1;

        public bool IsDeleted { get; set; }
    }
}
