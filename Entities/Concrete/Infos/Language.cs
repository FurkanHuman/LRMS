using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Language : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required, MaxLength()]
        public string LanguageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
