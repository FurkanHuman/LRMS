using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class EMaterialFile : IEntity
    {
        [Key, JsonIgnore]
        public ulong Id { get; set; }

        public string FileName { get; set; }

        public string Title { get; set; }

        public double FileSizeMB { get; set; }

        public bool IsSecret { get; set; }
    }
}
