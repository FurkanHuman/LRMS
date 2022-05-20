using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Country : IEntity
    {
        [Key, JsonIgnore]
        public ulong Id { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string CountryCode { get; set; }

        public List<City> Cities { get; set; }

        public bool IsDeleted { get; set; }
    }
}