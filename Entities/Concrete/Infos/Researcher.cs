using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Researcher : FirstPagePersonBase, IEntity
    {
        [Required]
        public string NamePreAttachment { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required]
        public University University { get; set; }

        public IList<AcademicJournal> AcademicJournals { get; set; }
        public IList<Dissertation> Dissertations { get; set; }
    }
}
