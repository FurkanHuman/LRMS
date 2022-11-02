using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class Thesis : MaterialBase, IEntity
{
    public Guid UniversityId { get; set; }

    public byte ThesisDegree { get; set; }

    public Guid ResearcherId { get; set; }

    public Researcher Researcher { get; set; }

    public Guid ConsultantId { get; set; }

    public int CityId { get; set; }

    public City City { get; set; }

    public ushort DateTimeYear { get; set; }

    public int LanguageId { get; set; }

    public Language Language { get; set; }

    public int ThesisNumber { get; set; }

    public bool PermissionStatus { get; set; }

    public bool ApprovalStatus { get; set; }

    public Consultant Consultant { get; set; }
    public University University { get; set; }
    public IList<Kit> Kits { get; set; }
}
