using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class CoverImage : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }
    }
}
