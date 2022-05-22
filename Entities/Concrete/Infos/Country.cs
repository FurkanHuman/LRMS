using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Country : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public bool IsDeleted { get; set; }
    }
}