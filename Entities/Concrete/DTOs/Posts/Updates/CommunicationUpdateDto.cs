namespace Entities.Concrete.DTOs.Posts.Updates
{
    public class CommunicationUpdateDto : IUpdateDto
    {
        public Guid Id { get; set; }

        public string CommunicationName { get; set; }

        public string PhoneNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public bool IsDeleted { get; set; }
    }
}
