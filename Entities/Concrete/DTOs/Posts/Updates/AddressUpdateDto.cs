namespace Entities.Concrete.DTOs.Posts.Updates
{
    public class AddressUpdateDto : IUpdateDto
    {
        public Guid Id { get; set; }

        public string AddressName { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string PostalCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string? GeoLocation { get; set; }

        public bool IsDeleted { get; set; }
    }
}
