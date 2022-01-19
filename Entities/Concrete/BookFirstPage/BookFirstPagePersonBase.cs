using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.BookFirstPage
{
    public class BookFirstPagePersonBase
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string? SurName { get; set; }

    }
}
