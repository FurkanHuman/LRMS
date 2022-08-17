using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Infos
{
    public class City : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public bool IsDeleted { get; set; }
    }
}