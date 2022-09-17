namespace Entities.Concrete.Entities.Mains
{
    public class Poster : MaterialBase, IEntity
    {
        public Guid OtherPeopleId { get; set; }

        public OtherPeople Owner { get; set; }

        public Guid ImageId { get; set; }

        public bool IsDestroyed { get; set; }

        public Image Image { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
