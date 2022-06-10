using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class AcademicJournal : MaterialBase, IEntity
    {
        [Required]
        public Guid ResearcherId { get; set; }

        [Required]
        public Guid EditorId { get; set; }

        [Required]
        public Guid PublisherId { get; set; }

        [Required]
        public Guid ReferenceId { get; set; }

        [Required]
        public ushort DateOfYear { get; set; }

        [Required]
        public ushort Volume { get; set; }

        [Required]
        public ushort AJNumber { get; set; }

        [Required]
        public ushort StartPageNumber { get; set; }

        [Required]
        public ushort EndPageNumber { get; set; }

        public bool IsSecret { get; set; }

        public IList<Researcher> Researchers { get; set; }

        public IList<Editor> Editors { get; set; }

        public IList<Publisher> Publishers { get; set; }

        public IList<Reference> References { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}