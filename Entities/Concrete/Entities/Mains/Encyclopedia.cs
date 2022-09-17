namespace Entities.Concrete.Entities.Mains
{
    public class Encyclopedia : BasePaper, IEntity
    {
        public uint SequenceNumber { get; set; }

        public Guid ReferenceId { get; set; }

        public IList<Reference> References { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}
