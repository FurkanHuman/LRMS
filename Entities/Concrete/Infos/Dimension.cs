using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Dimension : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }
    }
}
