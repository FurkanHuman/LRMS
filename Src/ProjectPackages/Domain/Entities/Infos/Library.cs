using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Domain.Entities.Infos;

public class Library : BaseEntity<Guid>, IEntity
{
    public byte LibraryType { get; set; }

    public Guid AddressId { get; set; }

    public Address Address { get; set; }

    public Guid CommunicationId { get; set; }
    public Communication Communication { get; set; }
}