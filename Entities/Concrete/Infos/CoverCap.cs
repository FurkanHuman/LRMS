using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class CoverCap : IEntity
    {// kitap kapağı tipi, karton, deri,  vs vs
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required, MinLength(2)]
        public string BookSkinType { get; set; }
    }
}
