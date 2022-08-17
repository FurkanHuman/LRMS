namespace Entities.Concrete.Entities.Mains
{
    public class MusicalNote : MaterialBase, IEntity
    {
        [Required]
        public Guid ComposerId { get; set; }

        [Required]
        public DateTime DateOfWriting { get; set; }

        public IList<Composer> Composers { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}