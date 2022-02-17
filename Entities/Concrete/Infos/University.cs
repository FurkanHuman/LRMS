using Core.Entities.Abstract;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class University : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string UniversityName { get; set; }

        public string Institute { get; set; }

        [Required]
        public Branch Branch { get; set; }

        public bool IsDeleted { get; set; }
    }
}