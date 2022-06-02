using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Edition : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required]
        public int EditionNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}
