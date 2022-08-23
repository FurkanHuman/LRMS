namespace Entities.Concrete.DTOs.Posts.Adds
{
    public class AddressAddDto : IAddDto
    {
        public string AddressName { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string PostalCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string? GeoLocation { get; set; }
    }
}
