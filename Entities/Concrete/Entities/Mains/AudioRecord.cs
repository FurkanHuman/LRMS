namespace Entities.Concrete.Entities.Mains
{
    public class AudioRecord : MaterialBase, IEntity
    {
        public Guid OwnerId { get; set; }

        public DateTime RecordDate { get; set; }

        public DateTime RecordEndDate { get; set; }

        public float RecordingLength { get; set; }

        public OtherPeople Owner { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}
