using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Infos
{
    public class Country : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public bool IsDeleted { get; set; }

        public IList<City> Cities { get; set; }
    }
}