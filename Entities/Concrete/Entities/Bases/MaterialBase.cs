namespace Entities.Concrete.Entities.Bases
{
    public class MaterialBase : BaseEntity<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Guid TechnicalPlaceholdersId { get; set; }

        public Guid StockId { get; set; }

        public Guid CounterId { get; set; }

        public Guid? DimensionsId { get; set; }

        public Guid? EMaterialFilesId { get; set; }

        public decimal? Price { get; set; }

        public byte State { get; set; } // indicates the state level of the material.

        public byte? SecretLevel { get; set; } // indicates the level of secrecy.

        public Stock Stock { get; set; }

        public Counter Counter { get; set; }

        public IList<Category> Categories { get; set; }

        public IList<Dimension>? Dimensions { get; set; }

        public IList<EMaterialFile>? EMaterialFiles { get; set; }

        public IList<TechnicalPlaceholder> TechnicalPlaceholders { get; set; }
    }
}
