using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class Publisher : BaseEntity<Guid>, IEntity
{
    public Guid AddressId { get; set; }

    public Address Address { get; set; }

    public Guid CommunicationId { get; set; }

    public Communication Communication { get; set; }

    public DateTime DateOfPublication { get; set; }

    public IList<AcademicJournal> AcademicJournals { get; set; }
}