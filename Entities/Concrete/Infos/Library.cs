using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Library:IEntity
    {
        [Key, JsonIgnore]
        public ulong Id { get; set; }

        [Required, MaxLength(512)]
        public string Name { get; set; }

        [Required, MaxLength(512)]
        public string Address { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}