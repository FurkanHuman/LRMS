namespace Entities.Concrete.Entities.Mains
{
    public class AudioRecord : MaterialBase, IEntity
    {
        [Required]
        public string Owner { get; set; } // change a otherPeople class todo. rebuid database table

        [Required]
        public DateTime RecordDate { get; set; }

        public DateTime RecordEndDate { get; set; }

        public float RecordingLength { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
