using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.BookCover
{
    public class BookType : IEntity
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public int BookTypeNumber { get; set; }
    }
}
