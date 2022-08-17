namespace Entities.Concrete.Entities.Mains
{
    public class CartographicMaterial : MaterialBase, IEntity
    {
        [Required]
        public Guid ImageId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public IList<Image> Images { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
