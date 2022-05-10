using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Entities.Concrete.Infos
{
    public class Publisher : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Required, MaxLength(256)]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string? WebSite { get; set; }

        public DateTime DateOfPublication { get; set; }

        public bool IsDeleted { get; set; }
    }
}