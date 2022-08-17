using Core.Entities.Abstract;

namespace Entities.Concrete.DTOs.Infos
{
    public class AddressDto : IDto
    {
        public Guid Id { get; set; }

        public string AddressName { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string PostalCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string? GeoLocation { get; set; }
    }
}
