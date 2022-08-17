namespace Entities.Concrete.Entities.Mains
{
    public class GraphicalImage : MaterialBase, IEntity
    {
        [Required]
        public DateTime ImageCreatedDate { get; set; }

        [Required]
        public Guid ImageId { get; set; }

        public Image Image { get; set; }

        public Guid OtherPeopleId { get; set; }

        public OtherPeople OtherPeople { get; set; }

        public bool IsDestroyed { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
