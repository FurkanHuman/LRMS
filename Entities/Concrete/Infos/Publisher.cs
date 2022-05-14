using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Entities.Concrete.Infos
{
    public class Publisher : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Communication Communication { get; set; }

        public DateTime DateOfPublication { get; set; }

        public bool IsDeleted { get; set; }
    }
}