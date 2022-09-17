namespace Entities.Concrete.Entities.Mains
{
    public class Magazine : BasePaper, IEntity
    {
        public byte MagazineType { get; set; }

        public uint Volume { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
