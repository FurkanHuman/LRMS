using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Domain.Entities.Infos;

public class Communication : BaseEntity<Guid>, IEntity
{
    public string PhoneNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string Email { get; set; }

    public string WebSite { get; set; }
}
