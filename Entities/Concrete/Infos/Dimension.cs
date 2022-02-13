using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Dimension : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Length { get; set; }
    }
}
