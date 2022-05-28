using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Address : IEntity
    {
        [Key, JsonIgnore]
        public Guid Id { get; set; }

        [Required]
        public string AddressName { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
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
