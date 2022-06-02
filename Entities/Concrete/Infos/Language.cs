using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Language : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
