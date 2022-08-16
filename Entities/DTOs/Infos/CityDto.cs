using Core.Entities.Abstract;

namespace Entities.DTOs.Infos
{
    public class CityDto : IDto
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public int CountryId { get; set; }
    }
}
