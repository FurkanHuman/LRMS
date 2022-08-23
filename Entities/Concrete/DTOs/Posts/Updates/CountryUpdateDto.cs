namespace Entities.Concrete.DTOs.Posts.Updates
{
    public class CountryUpdateDto : IUpdateDto
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public bool IsDeleted { get; set; }
    }
}
