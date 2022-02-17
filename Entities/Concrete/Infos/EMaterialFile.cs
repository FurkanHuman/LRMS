using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class EMaterialFile : IEntity
    {
        [Key, JsonIgnore]
        public ulong Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double FileSizeMB { get; set; }

        public bool IsSecret { get; set; }
    }
}
