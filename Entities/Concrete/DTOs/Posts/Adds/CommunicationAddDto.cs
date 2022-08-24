namespace Entities.Concrete.DTOs.Posts.Adds
{
    public class CommunicationAddDto : IAddDto
    {
        public string CommunicationName { get; set; }

        public string PhoneNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }
    }
}
