namespace Entities.Concrete.DTOs.Posts.Adds
{
    public class CityAddDto : IAddDto
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
