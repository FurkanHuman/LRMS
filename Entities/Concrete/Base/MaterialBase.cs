using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Base
{
    public class MaterialBase
    {
        [Key, JsonIgnore]
        public ulong Id { get; set; }

        [Required, MaxLength(512)]
        public string Name { get; set; }

        [Required, MaxLength(512)]
        public string Title { get; set; }

        [Required, MaxLength(512)]
        public string Description { get; set; }

        [Required]
        public List<Category> Categories { get; set; }

        [Required]
        public List<TechnicalPlaceholder> TechnicalPlaceholders { get; set; }

        [Required]
        public Dimension Dimension { get; set; }

        [Required, MaxLength(512)]
        public string State { get; set; }
    }
}
