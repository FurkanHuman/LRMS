namespace Entities.Concrete.Entities.Bases
{
    public class MaterialBase : BaseEntity<Guid>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public Guid TechnicalPlaceholdersId { get; set; }

        [Required]
        public Guid StockId { get; set; }

        [Required]
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
