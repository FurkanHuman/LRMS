using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.BookFirstPage
{
    public class Publisher : IEntity
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Address { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(15)]
        public string FaxNumber { get; set; }

        [Required]
        [MaxLength(64)]
        public string WebSite { get; set; }

    }
}