using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class Researcher : FirstPagePersonBase, IEntity
{
    public string NamePreAttachment { get; set; }

    public string Specialty { get; set; }

    public Guid UniversityId { get; set; }

    public University University { get; set; }

    public IList<AcademicJournal> AcademicJournals { get; set; }
    public IList<Dissertation> Dissertations { get; set; }
}
