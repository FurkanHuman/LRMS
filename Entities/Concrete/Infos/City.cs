using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class City : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }

        public bool IsDeleted { get; set; }
    }
}