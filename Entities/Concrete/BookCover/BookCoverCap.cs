using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.BookCover
{
    public class BookCoverCap : IEntity
    {// kitap kapağı tipi, karton, deri,  vs vs
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string BookSkinType { get; set; }
    }
}
