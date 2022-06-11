using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class City : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }

        public bool IsDeleted { get; set; }

        public int CountryId { get; set; }
        
        public Country Country { get; set; }
    }
}