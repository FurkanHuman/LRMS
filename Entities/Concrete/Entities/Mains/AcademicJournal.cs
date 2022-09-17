namespace Entities.Concrete.Entities.Mains
{
    public class AcademicJournal : MaterialBase, IEntity
    {
        public Guid ResearcherId { get; set; }

        public Guid EditorId { get; set; }

        public Guid PublisherId { get; set; }

        public Guid ReferenceId { get; set; }

        public ushort DateOfYear { get; set; }

        public ushort Volume { get; set; }

        public ushort AJNumber { get; set; }

        public ushort StartPageNumber { get; set; }

        public ushort EndPageNumber { get; set; }

        public IList<Researcher> Researchers { get; set; }

        public IList<Editor> Editors { get; set; }

        public IList<Publisher> Publishers { get; set; }

        public IList<Reference> References { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}