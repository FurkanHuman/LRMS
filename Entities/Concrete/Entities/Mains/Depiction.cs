namespace Entities.Concrete.Entities.Mains
{
    public class Depiction : MaterialBase, IEntity
    {
        public Guid ImageId { get; set; }

        public Image Image { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
