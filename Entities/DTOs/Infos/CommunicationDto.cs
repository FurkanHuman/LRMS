using Core.Entities.Abstract;

namespace Entities.DTOs.Infos
{
    public class CommunicationDto : IDto
    {
        public Guid Id { get; set; }

        public string CommunicationName { get; set; }

        public string PhoneNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }
    }
}
