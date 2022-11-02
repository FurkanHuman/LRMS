using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Domain.Entities.Infos;

public class Address : BaseEntity<Guid>, IEntity
{
    public int CountryId { get; set; }

    public Country Country { get; set; }

    public int CityId { get; set; }

    public City City { get; set; }

    public string PostalCode { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string? GeoLocation { get; set; }
}
