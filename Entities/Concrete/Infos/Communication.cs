using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Communication : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CommunicationName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? FaxNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WebSite { get; set; }

        public bool IsDeleted { get; set; }
    }
}
