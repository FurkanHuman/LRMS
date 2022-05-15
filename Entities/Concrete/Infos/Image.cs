using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Image : IEntity
    {
        [Key, JsonIgnore]
        public Guid Id { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }
    }
}
