using Core.Domain.Bases;

namespace Domain.Entities.Bases;

public class FirstPagePersonBase : BaseEntity<Guid>
{
    public string SurName { get; set; }
}
