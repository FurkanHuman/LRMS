using Core.Entities.Abstract;

namespace Entities.Concrete.DTOs.Infos
{
    public class CountryDto : IDto
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }
    }
}
