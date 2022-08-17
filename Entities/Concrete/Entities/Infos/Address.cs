namespace Entities.Concrete.Entities.Infos
{
    public class Address : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string AddressName { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public string AddressLine2 { get; set; }

        public string? GeoLocation { get; set; }

        public bool IsDeleted { get; set; }
    }
}
