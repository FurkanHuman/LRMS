namespace Entities.Concrete.DTOs.Posts.Updates
{
    public class CityUpdateDto : IUpdateDto
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public int CountryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
