using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Cover
{
    public class CoverImage : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public bool IsDeleted { get; set; }
    }
}
