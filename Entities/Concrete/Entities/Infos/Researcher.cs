﻿using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class Researcher : FirstPagePersonBase, IEntity
    {
        [Required]
        public string NamePreAttachment { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required]
        public Guid UniversityId { get; set; }

        public University University { get; set; }

        public IList<AcademicJournal> AcademicJournals { get; set; }
        public IList<Dissertation> Dissertations { get; set; }
    }
}
