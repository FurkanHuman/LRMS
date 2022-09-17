namespace Entities.Concrete.Entities.Mains
{
    public class Microform : MaterialBase, IEntity
    {
        public string Scale { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
