namespace Entities.Concrete.Entities.Mains
{
    public class NewsPaper : BasePaper, IEntity
    {
        public string NewsPaperName { get; set; }

        public uint Number { get; set; }

        public DateTime Date { get; set; }

        public bool IsDestroyed { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
