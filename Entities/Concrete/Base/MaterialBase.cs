using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Base
{
    public class MaterialBase
    {
        [Key, ]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<Category> Categories { get; set; }

        [Required]
        public List<TechnicalPlaceholder> TechnicalPlaceholders { get; set; }

        [Required]
        public Dimension Dimension { get; set; }

        public List<EMaterialFile>? EMaterialFiles { get; set; }

        public string State { get; set; }

        public byte SecretLevel { get; set; }
    }
}
