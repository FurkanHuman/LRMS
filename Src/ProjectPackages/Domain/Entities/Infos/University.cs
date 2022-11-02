using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class University : BaseEntity<Guid>, IEntity
{
    public string Institute { get; set; }

    public Guid AddressId { get; set; }

    public Address Address { get; set; }

    public int BranchId { get; set; }

    public Branch Branch { get; set; }

    public IList<Dissertation> Dissertations { get; set; }
}