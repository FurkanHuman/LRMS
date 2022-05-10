using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Base
{
    public class MaterialBase
    {
        [Key, JsonIgnore]
        public ulong Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Category> Categories { get; set; }

        public List<TechnicalPlaceholder> TechnicalPlaceholders { get; set; }

        public EMaterialFile? EMaterialFile { get; set; }

        public Dimension Dimension { get; set; }

        public string State { get; set; }
    }
}
