namespace Entities.Concrete.DTOs.Posts.Adds
{
    public class CountryAddDto : IAddDto
    {
        public string CountryName { get; set; }

        public string CountryCode { get; set; }
    }
}
